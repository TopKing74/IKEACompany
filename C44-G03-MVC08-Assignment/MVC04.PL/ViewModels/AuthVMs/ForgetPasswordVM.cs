using System.ComponentModel.DataAnnotations;

namespace MVC04.PL.ViewModels.AuthVMs
{
    public class ForgetPasswordVM
    {
        [Required]
        [EmailAddress (ErrorMessage = "Email is Invalid")]
        public string Email { get; set; } = null!;
    }
}
