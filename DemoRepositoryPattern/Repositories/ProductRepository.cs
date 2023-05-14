using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoRepositoryPattern.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
