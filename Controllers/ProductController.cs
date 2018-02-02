using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PGCRTX.Models;

namespace PGCRTX.Controllers
{
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
    }
}
