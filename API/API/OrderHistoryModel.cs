using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API
{
    [Table("tblOrderHistory")]
    public class OrderHistoryModel
    {
        [Key]
        [Required]
        public int OrderId { get; set; }
        [Required]
        
        public string? OrderDate { get; set; }
        [Required]
        [ForeignKey("UserModel")]
        public string? Username { get; set; }
        public UserModel? UserModel { get; set; }

        [Required]
        [ForeignKey("SellerModel")]
        public string? Sellername { get; set; }
        public SellerModel? SellerModel { get; set; }

        [Required]
        [ForeignKey("ProductsModel")]
        public int PId { get; set; }
        public ProductsModel? ProductsModel { get; set; }

        [Required]
        public int QuantityOrdered { get; set; }

    }
}
