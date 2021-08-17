using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCCoreApp.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public string Index(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //        return "Welcome to ASP.NET Core MVC";
        //    else
        //        return $"Hello, {id}! Welcome to ASP.NET Core MVC";
        //}
    }
}
