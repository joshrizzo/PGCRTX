using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PGCRTX.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName {get;set;}

        [Required]
        public string LastName {get;set;}
    }
}