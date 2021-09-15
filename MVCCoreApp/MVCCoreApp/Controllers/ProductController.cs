using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCCoreApp.Models;

namespace MVCCoreApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        
        {
            //return View();
            return Ok();
        }

        // Fail: http://localhost:6001/product/edit
        // OK: http://localhost:6001/product/modify
        //[ActionName("modify")]
        //[Route("Product/Modify")]
        //[NonAction]
        //public string Edit()
        //{
        //    return "Hello from edit method";
        //}

        [HttpGet]
        public ActionResult Edit(string id)
        {
            // Return the Edit Form
            //return View();
            // Redirect sang 1 URL hoặc Action (=> Product/Index)
            //return RedirectToAction("Index", "Product");
            return RedirectToAction("Index");
        }

        // POST: product
        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            // Update the Database here
            return Ok();
        }

        // GET: product
        [HttpGet]
        public List<ProductModel> GetAll()
        {
            return new List<ProductModel>()
            {
                new ProductModel(){Name = "Product 1"},
                new ProductModel(){Name = "Product 2"}
            };
        }


        // GET: product/10
        [HttpGet("{id}")]
        public IActionResult GetByID(long id)
        {
            // TODO: Get All data
            return Ok();
        }

        // POST: product
        [HttpPost()]
        public IActionResult Create(ProductModel product)
        {
            // TODO: Create a product in DB
            return Ok();
        }

        // PUT: product/10
        [HttpPut("{id}")]
        public IActionResult Udpate(string id, [FromBody]ProductModel product)  //kết quả bindding từ From Request
        {
            // TODO: Update a product in DB
            return Ok();
        }

        // DELETE: product/10
        [HttpPut("{id}")]
        public IActionResult Delete(string id)
        {
            // TODO: Delete a product in DB
            return Ok();
        }

    }
}
