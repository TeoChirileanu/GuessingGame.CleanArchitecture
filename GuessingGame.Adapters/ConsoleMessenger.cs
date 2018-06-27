using System;
using GuessingGame.BusinessRules;

namespace GuessingGame.Adapters {
    public class ConsoleMessenger : IMessenger {
        public void Deliver(string message) => Console.WriteLine(message);
    }
}