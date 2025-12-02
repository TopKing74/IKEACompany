using Twilio.Rest.Api.V2010.Account;

namespace MVC04.PL.Helper
{
    public interface ISMSService
    {
        MessageResource SendSMS(SMSMessage SmsMessage);
    }
}
