using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Weather.Web.Models
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base("DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Session_log> Session_logs { get; set; }
        //public DbSet<Rol> Roles { get; set; }
        //public DbSet<State> States { get; set; }
        public DbSet<Parameters> Parameters { get; set; }
        public DbSet<WeatherSummary> WeatherSummaries { get; set; }
    }

}