using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MVC04.PL.Settings;

namespace MVC04.PL.Helper
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<MailSettings> _options;

        public EmailService(IOptions<MailSettings> options)
        {
            this._options = options;
        }
        public void Send(Email email)
        {
            var mail = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_options.Value.Email),
                Subject = email.Subject,
            };
            mail.To.Add(MailboxAddress.Parse(email.To));
            mail.From.Add(new MailboxAddress(_options.Value.Email, _options.Value.DisplayName));
            var builder = new BodyBuilder();
            builder.TextBody = email.Body;

            mail.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            smtp.Connect(_options.Value.Host,
                _options.Value.Port,
                SecureSocketOptions.StartTls);
            smtp.Authenticate(_options.Value.Email, _options.Value.Password);
            smtp.Send(mail);
            smtp.Disconnect(true);
        }
    }
}
