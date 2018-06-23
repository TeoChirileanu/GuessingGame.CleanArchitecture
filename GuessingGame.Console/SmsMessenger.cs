using GuessingGame.ConsoleApplication.Properties;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace GuessingGame.ConsoleApplication {
    public class SmsMessenger : IMessenger {
        public void Deliver(string message) {
            TwilioClient.Init(Resources.TwilioAccountSid, Resources.TwilioAuthToken);

            MessageResource.Create(
                new PhoneNumber("+436764178797"),
                from: new PhoneNumber(Resources.TwilioPhoneNumber),
                body: message);
        }
    }
}