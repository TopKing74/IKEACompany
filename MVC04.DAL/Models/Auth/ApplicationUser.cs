using Microsoft.AspNetCore.Identity;


namespace MVC04.DAL.Models.Auth
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; }= null!;

        public bool IsAgree { get; set; }
    }
}
