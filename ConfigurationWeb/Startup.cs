using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Configuration.Data;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationWeb
{
    public class Startup
    {
        //inject configuration on app startup to use it in the Startup class
        public IConfiguration _configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ConfigurationContext>(options =>
                       options.UseSqlServer(_configuration.GetConnectionString("ConfigurationConnectionString")), ServiceLifetime.Scoped);

            services.AddMvc();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //allows serving static files (css, js, images, etc.)
            app.UseStaticFiles();

            //Change a configuration value on startup
            _configuration["TeamMessage"] = "tream Message changed in Startup.Configure";

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "manage",
                    template: "db/{controller=Management}/{action=Index}/{id?}");
            });

        }
    }
}
