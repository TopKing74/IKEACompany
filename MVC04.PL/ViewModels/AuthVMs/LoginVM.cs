using System.ComponentModel.DataAnnotations;

namespace MVC04.PL.ViewModels.AuthVMs
{
    public class LoginVM
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
