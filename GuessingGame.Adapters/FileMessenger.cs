using System;
using System.IO;
using GuessingGame.BusinessRules;
using GuessingGame.Shared.Properties;

namespace GuessingGame.Adapters {
    public class FileMessenger : IMessenger {
        private readonly string _pathToFile = Path.Combine(Resources.GameDirectory, "number.out");
        private string FullPathToFile => Environment.ExpandEnvironmentVariables(_pathToFile);

        public void Deliver(string message) {
            using (var stream = new StreamWriter(FullPathToFile)) {
                stream.Write(message);
            }
        }
    }
}