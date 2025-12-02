using System.ComponentModel.DataAnnotations;

namespace MVC04.PL.ViewModels.AuthVMs
{
    public class RegisterVM
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }=null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!; 
        public string UserName { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; } = null!;

            [Display(Name = "I Agree to the Terms and Conditions")] 
            public bool IsAgree { get; set; }

    }
}
