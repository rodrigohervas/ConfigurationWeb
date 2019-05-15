using Configuration.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Data
{
    public class ConfigurationContext: DbContext
    {
        public ConfigurationContext(DbContextOptions<ConfigurationContext> options): base(options)
        {

        }

        public DbSet<ConfigurationValue> ConfigurationValues { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbContextSeeder.Seed(modelBuilder);
        }
    }
}
