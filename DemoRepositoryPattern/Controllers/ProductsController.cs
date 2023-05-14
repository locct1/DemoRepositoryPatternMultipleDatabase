using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Dto.Product;
using DemoRepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoRepositoryPattern.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        public ProductsController(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult GellAllProducts()
        {
            //var products = _unitOfWork.Products.GetAll(product => product.Name == "Iphone 13", includeProperties: "Category");
            //var products = _unitOfWork.Products.GetAll(orderBy: q => q.OrderBy(p => p.Price), includeProperties: "Category");
            var products = _productRepository.GetAll(includeProperties: "Category");
            return Ok(products);

        }
        [HttpGet("{id}")]
        public IActionResult GetProdductById(int id)
        {
            var product = _productRepository.GetById(id);
            return Ok(product);

        }
        [HttpPost]
        public IActionResult CreateProduct(AddProductModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                CategoryId = model.CategoryId,
            };
            _productRepository.Add(product);
            _unitOfWork.Save();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, UpdateProductModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();

            }
            var product = new Product
            {
                Id = id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                CategoryId = model.CategoryId,
            };
            _productRepository.Update(product);
            _unitOfWork.Save();
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productRepository.Delete(id);
            _unitOfWork.Save();
            return Ok();

        }
    }
}
