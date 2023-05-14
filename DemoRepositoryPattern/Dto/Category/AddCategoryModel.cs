using System.ComponentModel.DataAnnotations;

namespace DemoRepositoryPattern.Dto.Category
{
    public class AddCategoryModel
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}
