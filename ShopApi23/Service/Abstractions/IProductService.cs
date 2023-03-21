using ShopApi23.Data;

namespace ShopApi23.Service.Abstractions
{
    public interface IProductService
    {
        Task<int> CreateProduct(string title, string description, double price, int categoryId);
        List<Product> GetAll();
        Product GetProduct(int id);
        Task<Product> UpdateProduct(int id, string title, string description, double price, int categoryId);
        Task<bool> DeleteProduct(int id);
    }
}
