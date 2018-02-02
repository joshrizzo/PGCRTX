using System;
using System.ComponentModel.DataAnnotations;

namespace PGCRTX.Models
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}
