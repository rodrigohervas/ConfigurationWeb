using Configuration.Web.CustomConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration.Web.CustomConfiguration
{
    /// <summary>
    /// This class defines the DB as the configuration storage source for our key/value config pairs
    /// DBConfigurationSource creates and returns an instance fo the DBConfigurationProvider
    /// </summary>
    public class DBConfigurationSource : IConfigurationSource
    {
        private Action<DbContextOptionsBuilder> _dbContextOptionsBuilder;

        public DBConfigurationSource(Action<DbContextOptionsBuilder> dbContextOptionsBuilder)
        {
            _dbContextOptionsBuilder = dbContextOptionsBuilder;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new DBConfigurationProvider(_dbContextOptionsBuilder);
        }
    }
}
