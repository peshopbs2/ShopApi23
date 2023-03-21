using ShopApi23.Data;
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

        public async Task<int> CreateCategory(string title)
        {
            var item = await _repository.CreateOrUpdate(new Category()
            {
                Title = title
            });
            return item.Id;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            return await _repository.RemoveById(id);
        }

        public List<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category GetCategory(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<Category> UpdateCategory(int id, string title)
        {
            var item = _repository.GetById(id);

            if (item != null)
            {
                item.Title = title;
                return await _repository.CreateOrUpdate(item);
            }
            else
            {
                return null;
            }
        }
    }
}
