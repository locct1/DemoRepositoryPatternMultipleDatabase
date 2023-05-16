using DemoRepositoryPattern.Data;

namespace DemoRepositoryPattern.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetCategoryById(int id);
        Task CreateCategory(Category newCategory);
        Task UpdateCategory(int id, Category updateCategory);
        Task DeleteCategory(int id);
        Task<IEnumerable<Category>> ValidateCategory(int id, string name);
    }
}
