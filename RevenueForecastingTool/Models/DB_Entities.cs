using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RevenueForecastingTool.Models
{
    public class DB_Entities : DbContext
    {
        public DB_Entities() : base("ForecastingToolCustomDb") { }
        public DbSet<AspNetUser> AspNetsUsers { get; set; }
        public DbSet<Project>  Projects { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<AspNetUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<Project>().ToTable("Projects");
            base.OnModelCreating(modelBuilder);


        }
    }
}