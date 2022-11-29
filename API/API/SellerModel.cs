using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    [Table("tblSeller")]
    public class SellerModel
    {
        [Required, Key]
        public string? Sellername { get; set; }
        [Required, StringLength(20, MinimumLength = 3, ErrorMessage = "Full name must be of length b/w 3 and 20")]
        public string? FullName { get; set; }
        [Required, StringLength(5, MinimumLength = 3, ErrorMessage = "Question cannot exceed length of 30")]
        public string? SecurityQuestion { get; set; }
        [Required, StringLength(20, MinimumLength = 5, ErrorMessage = "Answer should be of min length 5 and max length 20")]
        public string? Answer { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string? PhoneNo { get; set; }
        [Required, StringLength(20, MinimumLength = 5, ErrorMessage = "Shop name must be from length 5 to 20(including)")]
        public string? ShopName { get; set; }
        [Required, StringLength(5,MinimumLength = 5, ErrorMessage = "Enter the 5 character registration no to register")]
        public string? ShopRegNo { get; set; }

    }
}
