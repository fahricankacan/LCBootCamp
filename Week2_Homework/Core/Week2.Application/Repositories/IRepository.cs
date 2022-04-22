using Microsoft.EntityFrameworkCore;
using Week2.Domain.Common;

namespace Week2.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity 
    {
        DbSet<T> Table { get; }
    }
}
