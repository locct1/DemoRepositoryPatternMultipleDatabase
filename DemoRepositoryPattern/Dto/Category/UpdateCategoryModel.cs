using System.ComponentModel.DataAnnotations;

namespace DemoRepositoryPattern.Dto.Category
{
    public class UpdateCategoryModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}
