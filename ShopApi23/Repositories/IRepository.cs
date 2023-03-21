using ShopApi23.Data;

namespace ShopApi23.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(Func<T, bool> predicate);
        T GetById(int id);
        List<T> GetAll();
        List<T> Find(Func<T, bool> predicate);
        Task<T> CreateOrUpdate(T item);
        Task<bool> Remove(T item);
        Task<bool> RemoveById(int id);
    }
}
