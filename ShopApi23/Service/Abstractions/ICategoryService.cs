using ShopApi23.Data;
using ShopApi23.DTO.Request;
using ShopApi23.DTO.Response;

namespace ShopApi23.Service.Abstractions
{
    public interface ICategoryService
    {
        Task<int> CreateCategory(CategoryRequestDTO category);
        List<CategoryResponseDTO> GetAll();
        CategoryResponseDTO GetCategory(int id);
        Task<CategoryResponseDTO> UpdateCategory(int id, CategoryRequestDTO category);
        Task<bool> DeleteCategory(int id);
    }
}
