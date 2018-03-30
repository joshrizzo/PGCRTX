using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PGCRTX.Models;

namespace PGCRTX.Controllers
{
    [Authorize(Policy = "EditProduct")]
    public class ProductController : Controller
    {
        private MyDb database;

        public ProductController(MyDb database) {
            this.database = database;
        }

        public IActionResult List()
        {
            var model = database.Products.ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var model = database.Products.Single(prod => prod.ID == Id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            var orig = database.Products.Single(prod => prod.ID == model.ID);
            orig.Name = model.Name;
            orig.Cost = model.Cost;
            database.SaveChanges();

            return View(model);
        }
    }
}
