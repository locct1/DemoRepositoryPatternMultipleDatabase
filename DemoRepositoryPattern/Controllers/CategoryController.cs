using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Dto.Category;
using DemoRepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoRepositoryPattern.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productsService;

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productsService = productService;
        }
        [HttpGet]
        public async Task<IEnumerable<Category>> GellAllCategories()
        {
            var categories = await _categoryService.GetAll();
            return categories;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            Category findCategory = await this._categoryService.GetCategoryById(id);
            if (findCategory is null)
            {
                ModelState.AddModelError("Error", "Category not found");
                return BadRequest(ModelState);
            }
            return Ok(findCategory);

        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(AddCategoryModel model)
        {
            Category category = new Category
            {
                Name = model.Name,
            };
            await _categoryService.CreateCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category model)
        {
            if (id != model.Id)
            {
                return BadRequest();

            }
            Category findCategory = await _categoryService.GetCategoryById(id);
            if (findCategory is null)
            {
                ModelState.AddModelError("Error", "Category not found");
                return BadRequest(ModelState);
            }
            findCategory.Name = model.Name;
            await _categoryService.UpdateCategory(id, findCategory);
            return CreatedAtAction(nameof(GetCategoryById), new { id = findCategory.Id }, findCategory);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            Category findCategory = await _categoryService.GetCategoryById(id);
            if (findCategory is null)
            {
                ModelState.AddModelError("Error", "Category not found");
                return BadRequest(ModelState);
            }
            var listProduct = await _productsService.ListProductByCategoryId(findCategory.Id);
            if (listProduct.Count() > 0)
            {
                foreach (Product product in listProduct)
                {
                    product.CategoryId = null;
                    await this._productsService.UpdateProduct(product.Id, product);
                }
            }
            await _categoryService.DeleteCategory(findCategory.Id);
            return NoContent();
        }
    }
}
