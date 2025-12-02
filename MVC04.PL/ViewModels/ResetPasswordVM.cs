using System.ComponentModel.DataAnnotations;

namespace MVC04.PL.ViewModels
{
    public class ResetPasswordVM
    {
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "New Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; } = null!;

    }
}
