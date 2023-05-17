using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Interfaces;
using DemoRepositoryPattern.UnitOfWorks;

namespace DemoRepositoryPattern.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork<Product> _unitOfWork;
        public ProductService()
        {
            _unitOfWork = new UnitOfWork<Product>();
        }
        public async Task<IEnumerable<Product>> GetAll() => await _unitOfWork.Repository.GetAll();
        public async Task<Product?> GetProductById(int id) => await _unitOfWork.Repository.GetByID(id);
        public async Task CreateProduct(Product newProduct) => await _unitOfWork.Repository.Insert(newProduct);
        public async Task UpdateProduct(int id, Product updateProduct) => await _unitOfWork.Repository.Update(updateProduct);
        public async Task DeleteProduct(int id) => await _unitOfWork.Repository.Delete(id);
        public async Task<IEnumerable<Product>> ValidateProduct(int id, string name) => await _unitOfWork.Repository.GetAll(x => x.Id != id && x.Name == name);
        public async Task<IEnumerable<Product>> ListProductByCategoryId(int id) => await _unitOfWork.Repository.GetAll(x => x.CategoryId == id);

    }
}
