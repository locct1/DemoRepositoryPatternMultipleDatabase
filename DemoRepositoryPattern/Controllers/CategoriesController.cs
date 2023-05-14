using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Dto.Category;
using DemoRepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoRepositoryPattern.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult GellAllcategories()
        {
            var categories = _categoryRepository.GetAll();
            return Ok(categories);

        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryRepository.GetById(id);
            return Ok(category);

        }
        [HttpPost]
        public IActionResult CreateCategory(AddCategoryModel model)
        {
            Category category = new Category
            {
                Name = model.Name,
            };
            _categoryRepository.Add(category);

            _unitOfWork.Save();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Category model)
        {
            Category category = new Category
            {
                Id = id,
                Name = model.Name,
            };

            if (id != category.Id)
            {
                return BadRequest();

            }
            _categoryRepository.Update(category);
            _unitOfWork.Save();
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
            _unitOfWork.Save();
            return Ok();

        }
    }
}
