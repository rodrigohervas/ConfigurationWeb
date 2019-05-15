using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ConfigurationWeb.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;

        //inject IConfiguration into controller to access the configuration
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Loading a Configuration file section into a class
        /// </summary>
        /// <returns>ContactViewModel</returns>
        public IActionResult Contact()
        {
            //Bind the config info into a viewmodel object to pass it to the view
            var contact = _configuration.GetSection("Contact").Get<ContactViewModel>();
            
            return View(contact);
        }

        /// <summary>
        /// Load a Configuration file into a class
        /// </summary>
        /// <returns>List<ContactViewModel></returns>
        public IActionResult Team()
        {
            var team = _configuration.GetSection("Team").Get<List<ContactViewModel>>();

            return View(team);
        }

        /// <summary>
        /// Read info from contructor injected configuration (IConfiguration _configuration)
        /// Info comes from a custom configuration file (appsettings.CustomerInfo.json) added in Program.ConfigureAppConfiguration()
        /// Info is loaded into a viewmodel object to pass it to the view
        /// </summary>
        /// <returns>CustomerInfoViewModel</returns>
        public IActionResult Customer()
        {
            //Bind the config info into a viewmodel object to pass it to the view
            var customer = _configuration.GetSection("Customer").Get<CustomerInfoViewModel>();

            return View(customer);
        }

        public IActionResult Test()
        {
            return View();
        }

        /// <summary>
        /// Read info from contructor injected configuration (IConfiguration _configuration) and load it into ViewData objects for the view.
        /// </summary>
        /// <returns>ViewResult[""]</returns>
        public IActionResult Info()
        {
            ViewData["Message"] = _configuration["Message"].ToString();
            ViewData["InfoMessage"] = _configuration.GetValue<string>("InfoMessage", "An error has ocurred");

            return View();
        }

        /// <summary>
        /// Read info from contructor injected configuration (IConfiguration _configuration) and load it into ViewData objects for the view.
        /// </summary>
        /// <returns>ViewResult[""]</returns>
        public IActionResult Info2()
        {
            ViewData["Message"] = _configuration["Message"].ToString();
            ViewData["InfoMessage"] = _configuration.GetValue<string>("InfoMessage", "An error has ocurred");

            return View();
        }

    }
}