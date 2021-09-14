using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCCoreApp.Controllers
{
    public class PostController : Controller
    {
        public string PostsByID(int id)
        {
            return $"PostsByID : {id}";
        }
        public string PostsByPostName(string id)
        {
            return $"PostsByPostName : {id}";
        }
    }
}
