using Configuration.Data;
using Configuration.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration.Web.CustomConfiguration
{
    /// <summary>
    /// Our custom Configuration Provider has to extend IConfigurationProvider.
    /// Here it's done by extending the helper class ConfigurationProvider for implementing an IConfigurationProvider.
    /// Our custom provider contains the logic to get, set and access the configuration avlues at runtime.
    /// </summary>
    public class DBConfigurationProvider: ConfigurationProvider
    {
        // Declare a DbContextOptions (DbContextOptionsBuilder is its builder class) object that configures the options to be used by a DbContext
        // Every DbContext object needs a DbContextOptions to configure it to be able to perform any work
        Action<DbContextOptionsBuilder> _dbContextOptions;

        public DBConfigurationProvider(Action<DbContextOptionsBuilder> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        //Override the Load() method to fetch and store data
        public override void Load()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ConfigurationContext>();
            _dbContextOptions(dbContextOptionsBuilder);

            //Get all the configuration stored in ConfigurationContext
            using (var dbContext = new ConfigurationContext(dbContextOptionsBuilder.Options))
            {
                //Store the configuration into the Data object that is started in the ConfigurationProvider class constructor
                Data = dbContext.ConfigurationValues.ToDictionary(d => d.Key, d => d.Value);
            }
        }
    }
}
