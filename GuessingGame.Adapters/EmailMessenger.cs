using GuessingGame.BusinessRules;
using GuessingGame.Shared.Properties;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GuessingGame.Adapters {
    public class EmailMessenger : IMessenger {
        public void Deliver(string message) {
            var client = new SendGridClient(Resources.SendGridApiKey);
            var sendGridMessage = new SendGridMessage {
                From = new EmailAddress("no-reply@guessinggame.com"),
                Subject = "Result of your guessing",
                PlainTextContent = message
            };
            sendGridMessage.AddTo(new EmailAddress("teodorchirileanu@gmail.com"));
            client.SendEmailAsync(sendGridMessage);
        }
    }
}