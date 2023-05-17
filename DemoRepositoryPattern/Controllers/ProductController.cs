using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Dto.Product;
using DemoRepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoRepositoryPattern.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> GellAllProducts()
        {
            //var products = _unitOfWork.Products.GetAll(product => product.Name == "Iphone 13", includeProperties: "Category");
            //var products = _unitOfWork.Products.GetAll(orderBy: q => q.OrderBy(p => p.Price), includeProperties: "Category");
            var products = await _productService.GetAll();
            return products;

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            Product findProduct = await _productService.GetProductById(id);
            if (findProduct is null)
            {
                ModelState.AddModelError("Error", "Product not found");
                return BadRequest(ModelState);
            }
            return Ok(findProduct);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(AddProductModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                CategoryId = model.CategoryId,
            };
            await _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();

            }
            Product findProduct = await _productService.GetProductById(id);
            if (findProduct is null)
            {
                ModelState.AddModelError("Error", "Product not found");
                return BadRequest(ModelState);
            }

            findProduct.Name = model.Name;
            findProduct.Price = model.Price;
            findProduct.Description = model.Description;
            findProduct.CategoryId = model.CategoryId;
            await _productService.UpdateProduct(id, findProduct);
            return CreatedAtAction(nameof(GetProductById), new { id = findProduct.Id }, findProduct);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            Product findProduct = await _productService.GetProductById(id);
            if (findProduct is null)
            {
                ModelState.AddModelError("Error", "Product not found");
                return BadRequest(ModelState);
            }
            await _productService.DeleteProduct(findProduct.Id);
            return NoContent();

        }
    }
}
