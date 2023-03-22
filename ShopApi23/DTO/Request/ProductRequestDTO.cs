using ShopApi23.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ShopApi23.DTO.Request
{
    public class ProductRequestDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [PositiveNumber(ErrorMessage = "The price should be positive or zero.")]
        public double Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
