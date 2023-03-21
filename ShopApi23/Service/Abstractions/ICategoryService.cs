using ShopApi23.Data;

namespace ShopApi23.Service.Abstractions
{
    public interface ICategoryService
    {
        Task<int> CreateCategory(string title);
        List<Category> GetAll();
        Category GetCategory(int id);
        Task<Category> UpdateCategory(int id, string title);
        Task<bool> DeleteCategory(int id);
    }
}
