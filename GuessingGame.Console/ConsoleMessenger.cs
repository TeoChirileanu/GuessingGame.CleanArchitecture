using System;

namespace GuessingGame.ConsoleApplication {
    public class ConsoleMessenger : IMessenger {
        public void Deliver(string message) {
            Console.WriteLine(message);
        }
    }
}