using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Models
{
    [Table("tblUser")]
    public class UserModel
    {
        [Key]
        [Required]
        public string? Username { get; set; }

        [Required, StringLength(20, MinimumLength = 3, ErrorMessage = "Full name must be 3 character length minimum!")]
        public string? FullName { get; set; }

        [Required, DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        public string? ModifiedBy { get; set; }

        [Required, StringLength(50, MinimumLength = 10, ErrorMessage = "Address should be min of 5 and max 50 characters!")]
        public string? Address { get; set; }

        [StringLength(5, MinimumLength = 3, ErrorMessage = "Total questions cannot exceed 30")]
        public string? SecQuestion { get; set; }
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Answer should have min 5 and max 20 characters!")]
        public string? Answer { get; set; }

    }
}
