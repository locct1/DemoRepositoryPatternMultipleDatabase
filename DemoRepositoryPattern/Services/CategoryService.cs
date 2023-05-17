using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Interfaces;
using DemoRepositoryPattern.UnitOfWorks;

namespace DemoRepositoryPattern.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork<Category> _unitOfWork;
        public CategoryService()
        {
            _unitOfWork = new UnitOfWork<Category>();
        }
        public async Task<IEnumerable<Category>> GetAll() => await _unitOfWork.Repository.GetAll();
        public async Task<Category?> GetCategoryById(int id) => await _unitOfWork.Repository.GetByID(id);
        public async Task CreateCategory(Category newCategory) => await _unitOfWork.Repository.Insert(newCategory);
        public async Task UpdateCategory(int id, Category updateCategory) => await _unitOfWork.Repository.Update(updateCategory);
        public async Task DeleteCategory(int id) => await _unitOfWork.Repository.Delete(id);
        public async Task<IEnumerable<Category>> ValidateCategory(int id, string name) => await _unitOfWork.Repository.GetAll(x => x.Id != id && x.Name == name);
    }
}
