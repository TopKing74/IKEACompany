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
            Client.Credentials = new NetworkCredential("ahmedshaker.route@gmail.com", "dysvasjpwjnhqyjt");
            Client.Send("ahmedshaker.route@gmail.com", email.To, email.Subject, email.Body);
        }
    }
}
