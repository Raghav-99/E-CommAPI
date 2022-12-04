using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Models
{
    [Table("tblProducts")]
    public class ProductsModel
    {
        [Required]
        [Key]
        [DefaultValue(101)]
        public int PId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5,
            ErrorMessage = "Product name must be of min length 5 and max length 20")]
        public string? ProductName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5,
            ErrorMessage = "Product description must be of min length 5 and max length 100")]
        public string? ProductDescription { get; set; }
        [Required]
        [RegularExpression(@"Electronics|Fashion|Grocerries|Jewllery",
            ErrorMessage = "Allowed product types are: Electronics | Fashion | Grocerries | Jewllery")]
        public string? ProductType { get; set; }
        [Required(ErrorMessage = "Product count cannot be NULL")]
        [DefaultValue(0)]
        public int ProductCount { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        [Url]
        public string? ImageUrl { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
    }
}
