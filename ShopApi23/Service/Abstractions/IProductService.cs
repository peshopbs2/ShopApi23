using ShopApi23.Data;
using ShopApi23.DTO.Request;
using ShopApi23.DTO.Response;

namespace ShopApi23.Service.Abstractions
{
    public interface IProductService
    {
        Task<int> CreateProduct(ProductRequestDTO product);
        List<ProductResponseDTO> GetAll();
        ProductResponseDTO GetProduct(int id);
        Task<ProductResponseDTO> UpdateProduct(int id, ProductRequestDTO product);
        Task<bool> DeleteProduct(int id);
    }
}
