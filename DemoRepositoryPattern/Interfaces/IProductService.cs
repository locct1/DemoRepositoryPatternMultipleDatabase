using DemoRepositoryPattern.Data;

namespace DemoRepositoryPattern.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetProductById(int id);
        Task CreateProduct(Product newProduct);
        Task UpdateProduct(int id, Product updateProduct);
        Task DeleteProduct(int id);
        Task<IEnumerable<Product>> ValidateProduct(int id, string name);
        Task<IEnumerable<Product>> ListProductByCategoryId(int id);

    }
}
