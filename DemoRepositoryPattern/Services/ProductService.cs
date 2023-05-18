using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Interfaces;
using DemoRepositoryPattern.UnitOfWorks;

namespace DemoRepositoryPattern.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Product>> GetAll() => await _unitOfWork.GetRepository<Product>().GetAll();
        public async Task<Product?> GetProductById(int id) => await _unitOfWork.GetRepository<Product>().GetByID(id);
        public async Task CreateProduct(Product newProduct)
        {
            await _unitOfWork.GetRepository<Product>().Insert(newProduct);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateProduct(int id, Product updateProduct)
        {
            await _unitOfWork.GetRepository<Product>().Update(updateProduct);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteProduct(int id)
        {
            await _unitOfWork.GetRepository<Product>().Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<Product>> ValidateProduct(int id, string name) => await _unitOfWork.GetRepository<Product>().GetAll(x => x.Id != id && x.Name == name);

        public async Task<IEnumerable<Product>> ListProductByCategoryId(int id) => await _unitOfWork.GetRepository<Product>().GetAll(x => x.CategoryId == id);
    }
}
