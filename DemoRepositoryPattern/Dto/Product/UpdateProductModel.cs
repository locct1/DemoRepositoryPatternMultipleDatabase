using System.ComponentModel.DataAnnotations;

namespace DemoRepositoryPattern.Dto.Product
{
    public class UpdateProductModel
    {
        public int Id { get; set; }
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
