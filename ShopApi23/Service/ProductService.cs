using ShopApi23.Data;
using ShopApi23.Repositories;
using ShopApi23.Service.Abstractions;

namespace ShopApi23.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateProduct(string title, string description, double price, int categoryId)
        {
            var item = await _repository.CreateOrUpdate(new Product()
            {
                Title = title,
                Description = description,
                Price = price,
                CategoryId = categoryId
            });
            return item.Id;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _repository.RemoveById(id);
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Product GetProduct(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<Product> UpdateProduct(int id, string title, string description, double price, int categoryId)
        {
            var item = _repository.GetById(id);

            if (item != null)
            {
                item.Title = title;
                item.Description = description;
                item.Price = price;
                item.CategoryId = categoryId;
                return await _repository.CreateOrUpdate(item);
            }
            else
            {
                return null;
            }

        }
    }
}
