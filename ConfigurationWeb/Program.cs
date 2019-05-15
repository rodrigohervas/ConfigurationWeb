using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Configuration.Web.CustomConfiguration;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                
                //Add custom Json configuration files
                config.AddJsonFile("appsettings.CustomerInfo.json", optional: true, reloadOnChange: true);
                config.AddJsonFile("appsettings.Team.json", optional: true, reloadOnChange: true);
                config.AddJsonFile("Contact.json", optional: true, reloadOnChange: true);

                //Add custom DB configuration source
                AddDbConfiguration(config);
            })
            .UseStartup<Startup>();

        private static void AddDbConfiguration(IConfigurationBuilder configurationBuilder)
        {
            var configuration = configurationBuilder.Build();
            var connectionString = configuration.GetConnectionString("ConfigurationConnectionString");
            configurationBuilder.AddDBConfigurationProvider(options => options.UseSqlServer(connectionString));
        }

    }
}
