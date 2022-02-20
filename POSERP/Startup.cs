using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using System.IO;
using MediatR;
using POSERPAPI.Manager.Helper;
using System.Text.Json.Serialization;
using POSERPAPI.Manager.Interface;
using POSERPAPI.Manager.Implementation;
using POSERPAPI.Repository.Interface;
using POSERPAPI.Repository.Implementation;
using POSERPAPI.Repository.EDMX;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Swashbuckle.Swagger;

namespace POSERPAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // services.AddCors();
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:44334", "http://localhost:4200", "*")
            //                                .AllowAnyHeader()
            //                                .AllowAnyMethod();
            //        });
            //});
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddControllers(config =>
            {
                config.Filters.Add(typeof(ExceptionFilter));
            }).
            // comment code is used for ignore null property from json result
            //AddNewtonsoftJson(options =>
            //{
            //    options.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;
            //}).
            AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            #region 
            // JWT token configuration 
            var jwtSettings = Configuration.GetSection("JwtSettings");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value))
                };
            });
            //--------------------------------------
            #endregion
            // Email Service
            var emailConfig = Configuration.GetSection("EmailConfiguration");
            services.AddScoped<IEmailSender, EmailSenderManager>();





            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IUser, UserManagerRepo>();

            services.AddScoped<JwtHandler>();
            services.AddDbContext<POSERPDBContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("POSERPEntities")));

            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 6;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.User.RequireUniqueEmail = true;
            })
             .AddEntityFrameworkStores<POSERPDBContext>()
             .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromHours(2));

            services.AddScoped<DbContext, POSERPDBContext>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            ConfigurSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env , RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            Task.Run(() => this.CreateRoles(roleManager)).Wait();
            EnableSwagger(app);
        }
        private async Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (string rol in this.Configuration.GetSection("Roles").Get<List<string>>())
            {
                if (!await roleManager.RoleExistsAsync(rol))
                {
                    await roleManager.CreateAsync(new IdentityRole(rol));
                }
            }
        }
        private void ConfigurSwagger(IServiceCollection services)
        {
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("V1", new OpenApiInfo
            //    {
            //        Title = "POS ERP API",
            //        Version = "v1",
            //        Description = "POS",
            //    });
            //    //var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PosAPI.xml");
            //    //c.IncludeXmlComments(xmlPath);


            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject", Version = "v1.0.0" });

                //var securitySchema = new OpenApiSecurityScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.Http,
                //    Scheme = "bearer",
                //    Reference = new OpenApiReference
                //    {
                //        Type = ReferenceType.SecurityScheme,
                //        Id = "Bearer"
                //    }
                //};

                //c.AddSecurityDefinition("Bearer", securitySchema);

                //var securityRequirement = new OpenApiSecurityRequirement
                //{
                //    { securitySchema, new[] a{ "Berer" } }
                //};

                //c.AddSecurityRequirement(securityRequirement);

            });
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);


            //services.AddSwaggerGen();
        }
        private void EnableSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "pos service v1");

            });
        }
    }
}
