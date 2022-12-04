using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Models
{
    [Table("tblCommodities")]
    public class CommodityMapModel
    {
        [Key]
        [Required]
        [DefaultValue(1001)]

        public int CId { get; set; }
        [ForeignKey("SellerModel")]
        public string? Username { get; set; }
        public SellerModel? SellerModel { get; set; }
        [ForeignKey("ProductsModel")]
        public int PId { get; set; }
        public ProductsModel? ProductsModel { get; set; }
    }
}
