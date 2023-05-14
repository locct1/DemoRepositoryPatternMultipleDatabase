using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoRepositoryPattern.Dto.Product
{
    public class AddProductModel
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Required]
        [MaxLength(1000)]
        public string? Description { get; set; }
        public int? CategoryId { get; set; }

    }
}
