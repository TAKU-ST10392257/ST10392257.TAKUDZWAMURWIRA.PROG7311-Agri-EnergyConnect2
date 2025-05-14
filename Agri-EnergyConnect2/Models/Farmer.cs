using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Agri_EnergyConnect2.Models;

namespace Agri_EnergyConnect2.Models
{
    public class Farmer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
