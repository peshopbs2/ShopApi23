using ShopApi23.Data;

namespace ShopApi23.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly ShopContext _context;
        public Repository(ShopContext context)
        {
            _context = context;
        }

        public async Task<T> CreateOrUpdate(T item)
        {
            if (item.Id != 0)
            {
                item.ModifiedAt = DateTime.Now;
                _context.Set<T>().Update(item);
            }
            else
            {
                item.CreatedAt = DateTime.Now;
                _context.Set<T>().Add(item);
            }
            await _context.SaveChangesAsync();

            return item;
        }
        public List<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public T Get(Func<T, bool> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<bool> Remove(T item)
        {
            _context.Remove(item);
            int result = await _context.SaveChangesAsync();
            return result != 0;
        }

        public async Task<bool> RemoveById(int id)
        {
            T item = GetById(id);
            return item != null ? await Remove(item) : false;
        }
    }
}
