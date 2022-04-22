using Week2.Application.Repositories.CategoryRepository;
using Week2.Domain.Entities;
using Week2.Persistence.Contexts;

namespace Week2.Persistence.Repositories.CategoryRepository
{
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(Week2DbContext database) : base(database)
        {
        }
    }
}
