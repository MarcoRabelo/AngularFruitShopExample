using System.ComponentModel.DataAnnotations;

namespace FruitShop.Domain.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
