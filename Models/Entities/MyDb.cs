using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PGCRTX.Models;

namespace PGCRTX.Models
{
    public class MyDb : DbContext
    {
        public MyDb(DbContextOptions options) : base(options)
        {
            Seed();
        }

        protected MyDb()
        {
            Seed();
        }

        private void Seed()
        {
            Products.Add(new Product()
            {
                Name = "Thing",
                Cost = 2.0m
            });
            Products.Add(new Product()
            {
                Name = "Thing2",
                Cost = 2.0m
            });
            Products.Add(new Product()
            {
                Name = "Thing3",
                Cost = 3.2m
            });
            SaveChanges();
        }

        public DbSet<Product> Products { get; set; }
    }
}