using Configuration.Web.CustomConfiguration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration.Web.ViewComponents
{
    public class CodeViewComponent: ViewComponent
    {
        public CodeViewComponent()
        {

        }

        public IViewComponentResult Invoke(string name)
        {
            return View(name);
        }
    }
}
