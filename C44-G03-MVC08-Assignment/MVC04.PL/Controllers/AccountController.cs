using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC04.DAL.Models.Auth;
using MVC04.PL.Helper;
using MVC04.PL.ViewModels;
using MVC04.PL.ViewModels.AuthVMs;

namespace MVC04.PL.Controllers
{
    public class AccountController(UserManager<ApplicationUser> userManager, 
        SignInManager<ApplicationUser> signInManager,
        IEmailService _mailService,
        ISMSService sMSService) : Controller
    {

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM VM)
        {
            if (!ModelState.IsValid)
                return View(VM);
            var User = new ApplicationUser()
            {
                Email = VM.Email,
                UserName = VM.UserName,
                FirstName = VM.FirstName,
                LastName = VM.LastName

            };
            var Result = userManager.CreateAsync(User, VM.Password).Result;

            if(Result.Succeeded)
            return RedirectToAction("Login");

            else
            {
                foreach (var error in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(VM);
              }
            
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM VM)
        {
            if (!ModelState.IsValid)
                return View(VM);

            var User = userManager.FindByEmailAsync(VM.Email).Result;

            if (User is not null)
            {
                bool IsValid = userManager.CheckPasswordAsync(User, VM.Password).Result;
                if (IsValid)
                {
                   var Result=signInManager.PasswordSignInAsync(User, VM.Password, VM.RememberMe, false).Result;

                    if (Result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    if(Result.IsNotAllowed)
                    {                         
                        ModelState.AddModelError(string.Empty, "Not Allowed to login");
                        return View(VM);
                    }
                    if(Result.IsLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "Your Account is Locked");
                        return View(VM);
                    }
                }
            }
            
                ModelState.AddModelError(string.Empty, "Invalid Email or Password");
                return View(VM);
            
        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            signInManager.SignOutAsync().GetAwaiter().GetResult();
            return RedirectToAction("Login");
        }
        #endregion

        #region Forgot Password
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendResetPasswordLink(ForgetPasswordVM VM)
        {
            if(!ModelState.IsValid)
                return View("ForgetPassword",VM);

            var User = userManager.FindByEmailAsync(VM.Email).Result;
            if (User is not null)
            {
                var Token = userManager.GeneratePasswordResetTokenAsync(User).Result;
                var PasswordResetLink = Url.Action("ResetPassword", "Account",
                    new { Email = User.Email, token=Token }, Request.Scheme);

                var Email = new Email()
                {
                    Subject = "Reset Password",
                    To=User.Email,
                    Body = $"Your Reset Password Link is {PasswordResetLink}"
                };

                //EmailSettings.SendEmail(Email);
                _mailService.Send(Email);
                return RedirectToAction("CheckYourInbox");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email not found.");
                return View("ForgetPassword", VM);
            }
        }





        [HttpPost]
        public IActionResult SendResetPasswordLinkBySMS(ForgetPasswordVM VM)
        {
            if (!ModelState.IsValid)
                return View("ForgetPassword", VM);

            var User = userManager.FindByEmailAsync(VM.Email).Result;
            if (User is not null)
            {
                var Token = userManager.GeneratePasswordResetTokenAsync(User).Result;
                var PasswordResetLink = Url.Action("ResetPassword", "Account",
                    new { Email = User.Email, token = Token }, Request.Scheme);

                //var Email = new Email()
                //{
                //    Subject = "Reset Password",
                //    To = User.Email,
                //    Body = $"Your Reset Password Link is {PasswordResetLink}"
                //};
                var sms = new SMSMessage
                {
                    Body = PasswordResetLink,
                    PhoneNumber = User.PhoneNumber
                };

                //EmailSettings.SendEmail(Email);
                //_mailService.Send(Email);
                sMSService.SendSMS(sms);

                return Ok("Check Your SMS");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email not found.");
                return View("ForgetPassword", VM);
            }
        }


        [HttpGet]
        public IActionResult CheckYourInbox()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            TempData["Email"] = email;
            TempData["Token"] = token;
            return View();
        }
        //Pa$$w0rd
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM VM)
        {
            if (ModelState.IsValid)
            {

                string email = TempData["Email"] as string ?? string.Empty;
                string token = TempData["Token"]as string ?? string.Empty;
                if (string.IsNullOrEmpty(email))
                {
                    ModelState.AddModelError("", "Email is required to reset the password.");
                    return View(VM);
                }
                var User = await userManager.FindByEmailAsync(email);

                var result = await userManager.ResetPasswordAsync(User, token, VM.NewPassword);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(VM);
                }
            }
            return View(VM);

        }
        #endregion
    }
}
