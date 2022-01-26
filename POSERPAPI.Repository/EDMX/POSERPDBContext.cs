using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace POSERPAPI.Repository.EDMX
{
    public class POSERPDBContext : DbContext // : IdentityDbContext //Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<ApplicationUser>
    {
        public POSERPDBContext()
        {
        }
        public POSERPDBContext(DbContextOptions<POSERPDBContext> options) : base(options)
        {

        }
        //public LicenseDBContext(DbContextOptions<LicenseDBContext> options)
        //   : base(options)
        //{
        //}

       
        public DbSet<ErrorLog> ErrorLog { get; set; }
       
        public DbSet<CountryMaster> CountryMaster { get; set; }
      
        public DbSet<CityMaster> CityMaster { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<SalesMaster> salesMasters { get; set; }
        public DbSet<SaleTransaction> saleTransactions { get; set; }
        public DbSet<SaleTax> saleTaxes { get; set; }



        // sp



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Query<Class1>();
        //}

    }
}
