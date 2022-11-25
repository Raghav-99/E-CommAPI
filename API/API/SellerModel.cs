using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    [Table("tblSeller")]
    public class SellerModel
    {
        [Required, Key]
        public string? Username { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? SecurityQuestion { get; set; }
        [Required, StringLength(20)]
        public string? Answer { get; set; }

        public string? PhoneNo { get; set; }
        [Required, StringLength(30, MinimumLength = 10)]
        public string? ShopName { get; set; }
        [Required, StringLength(10, MinimumLength = 5)]
        public string? ShopRegNo { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string? ProductName { get; set; }
        [StringLength(300, MinimumLength = 50)]
        public string? ProductDetails { get; set; }


    }
}
