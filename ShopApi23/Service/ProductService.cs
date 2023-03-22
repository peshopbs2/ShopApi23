using ShopApi23.Data;
using ShopApi23.DTO.Request;
using ShopApi23.DTO.Response;
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

        public async Task<int> CreateProduct(ProductRequestDTO product)
        {
            var item = await _repository.CreateOrUpdate(new Product()
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId
            });
            return item.Id;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _repository.RemoveById(id);
        }

        public List<ProductResponseDTO> GetAll()
        {
            return _repository.GetAll()
                .Select(item => new ProductResponseDTO()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Price = item.Price,
                    CategoryId = item.CategoryId,
                    CategoryTitle = item.Category.Title,
                    CreatedAt = item.CreatedAt,
                    ModifiedAt = item.ModifiedAt
                })
                .ToList();
        }

        public ProductResponseDTO GetProduct(int id)
        {
            var item = _repository.GetById(id);
            return new ProductResponseDTO()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                Price = item.Price,
                CategoryId = item.CategoryId,
                CategoryTitle = item.Category.Title,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };
        }

        public async Task<ProductResponseDTO> UpdateProduct(int id, ProductRequestDTO product)
        {
            var item = _repository.GetById(id);

            if (item != null)
            {
                item.Id = id;
                item.Title = product.Title;
                item.Description = product.Description;
                item.Price = product.Price;
                item.CategoryId = product.CategoryId;
                
                var updatedItem = await _repository.CreateOrUpdate(item);
                return new ProductResponseDTO()
                {
                    Id = updatedItem.Id,
                    Title = updatedItem.Title,
                    Description = updatedItem.Description,
                    Price = updatedItem.Price,
                    CategoryId = updatedItem.CategoryId,
                    CategoryTitle = updatedItem.Category.Title,
                    CreatedAt = updatedItem.CreatedAt,
                    ModifiedAt = updatedItem.ModifiedAt
                };
            }
            else
            {
                return null;
            }

        }
    }
}
