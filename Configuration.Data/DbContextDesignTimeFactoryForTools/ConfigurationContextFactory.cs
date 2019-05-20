using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration.Data.DbContextDesignTimeFactoryForTools
{
    public class ConfigurationContextFactory : IDesignTimeDbContextFactory<ConfigurationContext>
    {
        public ConfigurationContextFactory()
        {

        }

        public ConfigurationContext CreateDbContext(string[] args)
        {
            //Add a configuration to get the connectionstring from appsettings.json
            IConfigurationRoot configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configurationBuilder.GetConnectionString("ConfigurationConnectionString");
            
            var optionsBuilder = new DbContextOptionsBuilder<ConfigurationContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ConfigurationContext(optionsBuilder.Options);
        }
    }
}
