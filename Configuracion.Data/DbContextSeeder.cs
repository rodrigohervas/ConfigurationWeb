using System;
using Configuration.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Configuration.Data
{
    static internal class DbContextSeeder
    {
        
        internal static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigurationValue>().HasData(
                new ConfigurationValue { Key = "http", Value = "http://localhost:5000" },
                new ConfigurationValue { Key = "https", Value = "https://localhost:5001" }, 
                new ConfigurationValue { Key = "ConfigurationConnectionStringDB", Value = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EFConfigurationDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False" }, 
                new ConfigurationValue { Key = "ASPNETCORE_ENVIRONMENT", Value = "Development" }, 
                new ConfigurationValue { Key = "Open Ports", Value = "2011, 2456, 8885"},
                new ConfigurationValue { Key = "sslPort", Value = "44303" },
                new ConfigurationValue { Key = "TestUser", Value = "John Smith" },
                new ConfigurationValue { Key = "TestUserGuid", Value = "d4acd337-5915-4e32-b978-6d216e8b0353" }, 

                new ConfigurationValue { Key = "Complex:Name", Value = "Marcel Proust" },
                new ConfigurationValue { Key = "Complex:Email", Value = "marcelproust@france.fr" },
                new ConfigurationValue { Key = "Complex:Position", Value = "Writer" },
                new ConfigurationValue { Key = "Complex:DateOfBirth", Value = "10 July 1871" },
                new ConfigurationValue { Key = "Complex:DateOfDeath", Value = "18 November 1922" },
                new ConfigurationValue { Key = "Complex:Address:Street", Value = "Avenue des Champs - Élysées 49" },
                new ConfigurationValue { Key = "Complex:Address:City", Value = "Paris" },
                new ConfigurationValue { Key = "Complex:Address:Zipcode", Value = "75008" },
                new ConfigurationValue { Key = "Complex:Address:Country", Value = "France" },

                new ConfigurationValue { Key = "Complex:Department:Name", Value = "IT Department" }, 
                new ConfigurationValue { Key = "Complex:Department:Description", Value = "The IT Department is responsible for the digital well-being of the organization." }, 

                new ConfigurationValue { Key = "Complex:Department:Production", Value = "Production Department"},
                new ConfigurationValue { Key = "Complex:Department:Research", Value = "Research and Development Department" },
                new ConfigurationValue { Key = "Complex:Department:Purchasing", Value = "Purchasing Department" }, 
                new ConfigurationValue { Key = "Complex:Department:Marketing", Value = "Marketing and Sales Department" }, 
                new ConfigurationValue { Key = "Complex:Department:HumanResources", Value = "Human Resources Management Department" }, 
                new ConfigurationValue { Key = "Complex:Department:Finance", Value = "Accounting and Finance Department" }
                );

            
        }
    }
}