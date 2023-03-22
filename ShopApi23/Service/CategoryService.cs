using ShopApi23.Data;
using ShopApi23.DTO.Request;
using ShopApi23.DTO.Response;
using ShopApi23.Repositories;
using ShopApi23.Service.Abstractions;

namespace ShopApi23.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateCategory(CategoryRequestDTO category)
        {
            var item = await _repository.CreateOrUpdate(new Category()
            {
                Title = category.Title
            });
            return item.Id;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            return await _repository.RemoveById(id);
        }

        public List<CategoryResponseDTO> GetAll()
        {
            return _repository.GetAll()
                .Select(item => new CategoryResponseDTO()
                {
                    Id = item.Id,
                    Title = item.Title,
                    CreatedAt = item.CreatedAt,
                    ModifiedAt = item.ModifiedAt
                })
                .ToList();
        }

        public CategoryResponseDTO GetCategory(int id)
        {
            var item = _repository.GetById(id);
            return new CategoryResponseDTO()
            {
                Id = item.Id,
                Title = item.Title,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };
        }

        public async Task<CategoryResponseDTO> UpdateCategory(int id, CategoryRequestDTO category)
        {
            var item = _repository.GetById(id);

            if (item != null)
            {
                item.Id = id;
                item.Title = category.Title;
                var editedItem = await _repository.CreateOrUpdate(item);
                return new CategoryResponseDTO()
                {
                    Id = editedItem.Id,
                    Title = editedItem.Title,
                    CreatedAt = editedItem.CreatedAt,
                    ModifiedAt = editedItem.ModifiedAt
                };
            }
            else
            {
                return null;
            }
        }
    }
}
