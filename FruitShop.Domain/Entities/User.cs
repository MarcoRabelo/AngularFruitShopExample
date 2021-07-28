using FruitShop.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace FruitShop.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        public bool Admin { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
