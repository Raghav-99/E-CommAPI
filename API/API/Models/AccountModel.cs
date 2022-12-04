using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Models
{
    [Keyless]
    public class AccountModel
    {
        // [Required]
        public string? EmailAddress { get; set; }

        //[Required, Key]
        public string? Username { get; set; }

        //[Required, DataType(DataType.Password), StringLength(50, MinimumLength = 7)]
        public string? Password { get; set; }

        //[Required, DataType(DataType.Password), Compare("Password", ErrorMessage = "Passwords don't match"), StringLength(50, MinimumLength = 7)]
        public string? ConfirmPassword { get; set; }

        // Common for User and Seller
        //[Required, StringLength(20, MinimumLength = 3, ErrorMessage = "Full name must be 3 character length minimum!")]
        public string? FullName { get; set; }

        //[Required, DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        public string? ModifiedBy { get; set; }

        //[Required, StringLength(50, MinimumLength = 10, ErrorMessage = "Address should be min of 5 and max 50 characters!")]
        public string? Address { get; set; }

        //[StringLength(5, MinimumLength = 3, ErrorMessage = "Total questions cannot exceed 30")]
        public string? SecQuestion { get; set; }
        //[StringLength(20, MinimumLength = 5, ErrorMessage = "Answer should have min 5 and max 20 characters!")]
        public string? Answer { get; set; }

        // Seller
        //--------
        //[Required, StringLength(20, MinimumLength = 5, ErrorMessage = "Shop name must be from length 5 to 20(including)")]
        public string? ShopName { get; set; }
        //[Required, StringLength(5, MinimumLength = 5, ErrorMessage = "Enter the 5 character registration no to register")]
        public string? ShopRegNo { get; set; }



    }
}
