namespace ShopApi23.DTO.Response
{
    public class ProductResponseDTO : BaseResponseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
    }
}
