using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PGCRTX.Models
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 100)]
        public decimal Cost { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
