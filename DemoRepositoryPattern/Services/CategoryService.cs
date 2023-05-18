using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Interfaces;
using DemoRepositoryPattern.UnitOfWorks;

namespace DemoRepositoryPattern.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Category>> GetAll() => await _unitOfWork.GetRepository<Category>().GetAll();
        public async Task<Category?> GetCategoryById(int id) => await _unitOfWork.GetRepository<Category>().GetByID(id);
        public async Task CreateCategory(Category newCategory) {
            await _unitOfWork.GetRepository<Category>().Insert(newCategory);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateCategory(int id, Category updateCategory) {
            await _unitOfWork.GetRepository<Category>().Update(updateCategory);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteCategory(int id) {
            await _unitOfWork.GetRepository<Category>().Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<Category>> ValidateCategory(int id, string name) => await _unitOfWork.GetRepository<Category>().GetAll(x => x.Id != id && x.Name == name);
    }
}
