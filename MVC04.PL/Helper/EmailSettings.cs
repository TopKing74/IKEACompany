using MVC04.DAL.Models.Auth;
using System.Net;
using System.Net.Mail;

namespace MVC04.PL.Helper
{
    public class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var Client = new SmtpClient("smtp.gmail.com", 587);
            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential("example@gmail.com", "password_here"); //i deleted real credentials for security reasons
            Client.Send("example@gmail.com", email.To, email.Subject, email.Body); //i deleted real credentials for security reasons
        }
    }
}
