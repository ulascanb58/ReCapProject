using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProjectDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-QE2NQQH\SQLEXPRESS;Database=ProjectDB;Trusted_Connection=true");
        }


        public DbSet<NCar> TBLCARS { get; set; }
        public DbSet<NBrand> TBLBRANDS { get; set; }
        public DbSet<NColor> TBLCOLORS { get; set; }
    }


}
