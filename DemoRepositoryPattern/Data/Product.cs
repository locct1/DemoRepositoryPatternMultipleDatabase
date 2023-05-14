using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoRepositoryPattern.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Required]
        [MaxLength(1000)]
        public string? Description { get; set; }
        [ForeignKey("CategorryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
