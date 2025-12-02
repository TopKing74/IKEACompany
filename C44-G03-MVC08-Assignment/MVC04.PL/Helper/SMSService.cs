
using Microsoft.Extensions.Options;
using MVC04.PL.Settings;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace MVC04.PL.Helper
{
    public class SMSService : ISMSService
    {
        private readonly IOptions<SMSSetting> _options;

        public SMSService(IOptions<SMSSetting> options)
        {
            this._options = options;
        }
        public MessageResource SendSMS(SMSMessage SmsMessage)
        {
            TwilioClient.Init(_options.Value.AccountSID, _options.Value.AuthToken);
            var message = MessageResource.Create(
                body: SmsMessage.Body,
                from: new Twilio.Types.PhoneNumber(_options.Value.TwilioPhoneNumber),
                to: SmsMessage.PhoneNumber
                );
            return message;
        }
    }
}
