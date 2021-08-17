using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCCoreApp.Models;

namespace MVCCoreApp.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    var model = new IndexModel();
        //    model.Message = "Hello from Model";
        //    return View(model);
        //}

        public IActionResult Index(int id)
        {
            var model = new IndexModel();
            model.Message = "Hello from Model, ID= "+ id.ToString();
            return View(model);
        }

        //public string Index()
        //{
        //    return "Hello from index methor of HomeController!";
        //}
    }
}
