using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API
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
        [ForeignKey("ProductModel")]
        public int PId { get; set; }
    }
}
