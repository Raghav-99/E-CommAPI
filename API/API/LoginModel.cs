using System.ComponentModel.DataAnnotations;

namespace API
{
    public class LoginModel
    {
        [Required, Key]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
