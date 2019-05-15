using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Configuration.Web.CustomConfiguration
{
    /// <summary>
    /// Class to define the Extension methods that we'll use to call the Custom Configuration Source from the app configuration
    /// </summary>
    public static class DBConfigurationSourceExtensions
    {
        public static IConfigurationBuilder AddDBConfigurationProvider(this IConfigurationBuilder configurationBuilder, Action<DbContextOptionsBuilder> dbContextOptionsBuilder)
        {
            return configurationBuilder.Add(new DBConfigurationSource(dbContextOptionsBuilder));
        }
    }
}
