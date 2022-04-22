using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories;
using Week2.Domain.Common;
using Week2.Persistence.Contexts;

namespace Week2.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly Week2DbContext _context;

        public ReadRepository(Week2DbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            return tracking ? Table.AsQueryable() : Table.AsNoTracking();
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            return await GetAll(tracking).FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }



        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            return await GetAll(tracking).FirstOrDefaultAsync(method);
        }


        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            return GetAll(tracking).Where(method);
        }
    }
}
