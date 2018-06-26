using System;
using System.IO;
using GuessingGame.BusinessRules;

namespace GuessingGame.Adapters {
    public class FileMessenger : IMessenger {
        private readonly string _file =
            Environment.ExpandEnvironmentVariables(@"%temp%\guessinggame\number.out");

        public void Deliver(string message) {
            using (var stream = new StreamWriter(_file)) {
                stream.Write(message);
            }
        }
    }
}