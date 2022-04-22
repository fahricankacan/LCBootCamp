using Week2.Domain.Common;

namespace Week2.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> models);
        bool Remove(T model);
        bool RemoveRange(List<T> models);
        Task<bool> Remove(string id);
        bool Update(T model);

        Task<int> SaveAsync();
    }
    
    
}
