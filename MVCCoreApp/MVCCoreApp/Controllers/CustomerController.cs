using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCCoreApp.Controllers
{
    public class CustomerController : Controller
    {
        [Route("khach-hang/vip")]
        public string Vip()
        {
            return "Khách hàng vip";
        }

        //[Route("")]                           // Set default when link = "/"
        [Route("khach-hang/normal/{id?}")]
        public IActionResult Normal(int id)
        {
            return Content($"Khách hàng thường với id: {id}");
        }
    }
}
