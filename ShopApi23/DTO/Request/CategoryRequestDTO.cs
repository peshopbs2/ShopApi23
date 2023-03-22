using System.ComponentModel.DataAnnotations;

namespace ShopApi23.DTO.Request
{
    public class CategoryRequestDTO
    {
        [Required(ErrorMessage = "Field title is required!")]
        [MinLength(3, ErrorMessage = "The title should be at least 3 symbols.")]
        [MaxLength(50, ErrorMessage = "The title should be at most 50 symbols.")]
        public string Title { get; set; }
    }
}
