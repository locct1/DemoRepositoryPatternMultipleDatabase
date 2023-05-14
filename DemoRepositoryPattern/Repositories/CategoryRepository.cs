using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoRepositoryPattern.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
