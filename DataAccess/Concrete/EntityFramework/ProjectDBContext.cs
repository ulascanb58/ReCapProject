using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProjectDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-QE2NQQH\SQLEXPRESS;Database=ProjectDB;Trusted_Connection=true");
        }


        public DbSet<NCar> TBL_CARS { get; set; }
        public DbSet<NBrand> TBL_BRANDS { get; set; }
        public DbSet<NColor> TBL_COLORS { get; set; }
        public DbSet<NCustomer> TBL_CUSTOMERS { get; set; }
        public DbSet<NUser> TBL_USERS { get; set; }
        public DbSet<NRental> TBL_RENTALS { get; set; }
        public DbSet<NCarImage> TBL_CARIMAGES { get; set; }
        public DbSet<NOperationClaim> TBL_OPERATION_CLAIMS { get; set; }
        public DbSet<NUserOperationClaim> TBL_USER_OPERATION_CLAIMS { get; set; }
    }


}
