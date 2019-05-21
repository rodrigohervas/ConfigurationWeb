using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Configuration.Data.Models;
using Microsoft.Extensions.Configuration;

namespace Configuration.Web.Controllers
{
    public class DBController : Controller
    {
        IConfiguration _configuration;

        public DBController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// Reading info from a custom DataBase configuration provider (DBConfigurationProvider) added in Program class
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {

            //Bind the config info into a Dictionary<string, string> object to pass it to the view
            var appInfo = new Dictionary<string, string>();
            appInfo.Add("ASPNETCORE_ENVIRONMENT", _configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT"));
            appInfo.Add("http", _configuration.GetValue<string>("http"));
            appInfo.Add("https", _configuration.GetValue<string>("https"));
            appInfo.Add("Open Ports", _configuration.GetValue<string>("Open Ports"));
            appInfo.Add("sslPort", _configuration.GetValue<string>("sslPort"));
            appInfo.Add("TestUser", _configuration.GetValue<string>("TestUser"));
            appInfo.Add("TestUserGuid", _configuration.GetValue<string>("TestUserGuid"));
            appInfo.Add("ConfigurationConnectionStringDB", _configuration.GetValue<string>("ConfigurationConnectionStringDB"));

            return View(appInfo);
        }

        /// <summary>
        /// Reading configuration from app configuration, and loading into Person object
        /// </summary>
        /// <returns>Person</returns>
        [Route("complex")]
        [Route("[controller]/ComplexObject")]
        public ActionResult ComplexObject()
        {
            //Bind the config info into a model POCO object (Person) to pass it to the view
            var complexObject = _configuration.GetSection("Complex").Get<Person>();

            return View(complexObject);
        }

        /// <summary>
        /// Reading configuration from app configuration, and loading into List<Department> object
        /// </summary>
        /// <returns>List<Department></returns>
        [Route("departments")]
        [Route("[controller]/departments")]
        public ActionResult Departments()
        {
            var departments = _configuration.GetSection("Complex:Departments").GetChildren();
            var departmentsList = new List<Department>();
            foreach (var item in departments)
            {
                departmentsList.Add(new Department { Name = item.Key, Description = item.Value });
            }

            return View(departmentsList);
        }

        /// <summary>
        /// Information page describing how to read configuration from a database
        /// </summary>
        /// <returns></returns>
        [Route("dbinfo")]
        [Route("[controller]/DBInfo")]
        public IActionResult DBInfo()
        {
            return View();
        }
    }
}