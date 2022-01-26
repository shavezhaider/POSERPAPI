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


            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

                    });
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
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IProductManager, ProductManager>();
            // services.AddMediatR(typeof(Startup));

            services.AddDbContext<POSERPDBContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("POSERPEntities")));


            services.AddScoped<DbContext, POSERPDBContext>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            ConfigurSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            EnableSwagger(app);
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
            services.AddSwaggerGen();
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
