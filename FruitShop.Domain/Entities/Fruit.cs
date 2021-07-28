using FruitShop.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace FruitShop.Domain.Entities
{
    public class Fruit : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Url]
        [MaxLength(500)]
        public string Image { get; set; }

        public long? Stock { get; set; }

        [Required]
        [Range(0, 9999999999.99)]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public decimal Price { get; set; }
    }
}
