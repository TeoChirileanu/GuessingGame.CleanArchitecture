using System;
using GuessingGame.ConsoleApplication.Properties;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GuessingGame.ConsoleApplication {
    public class EmailMessenger : IMessenger {
        public void Deliver(string message) {
            var client = new SendGridClient(Resources.SendGridApiKey);
            var sendGridMessage = new SendGridMessage {
                From = new EmailAddress("teodor@mobibam.com"),
                Subject = "Result of your guessing",
                PlainTextContent = message
            };
            sendGridMessage.AddTo(new EmailAddress("teodorchirileanu@gmail.com"));
            var response = client.SendEmailAsync(sendGridMessage);
            Console.WriteLine(response.Result.StatusCode);
        }
    }
}