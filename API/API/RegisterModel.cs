using System.ComponentModel.DataAnnotations;

namespace API
{
    public class RegisterModel
    {
        [Required]
        public string? EmailAddress { get; set; }

        [Required, Key]
        public string? Username { get; set; }

        [Required, DataType(DataType.Password), StringLength(50, MinimumLength = 7)]
        public string? Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password", ErrorMessage = "Passwords don't match"), StringLength(50, MinimumLength = 7)]
        public string? ConfirmPassword { get; set; }
    }
}
