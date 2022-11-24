using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    [Table("tblUser")]
    public class UserModel
    {
        [Key]
        [Required]
        public string? Username { get; set; }
        public string? ModifiedBy { get; set; }
        public string? DateOfBirth { get; set; }
        [StringLength(100,MinimumLength = 10)]
        public string? SecQuestion { get; set; }
        public string? Answer { get; set; }

    }
}
