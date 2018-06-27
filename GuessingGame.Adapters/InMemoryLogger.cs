using System;
using System.Text;
using GuessingGame.BusinessRules;

namespace GuessingGame.Adapters {
    public class InMemoryLogger : ILogger {
        private readonly StringBuilder _stringBuilder = new StringBuilder($"{DateTime.Now}\tLog started\n");

        public void Log(string message) => _stringBuilder.AppendLine($"{DateTime.Now}\t{message}");

        public string GetLog() => _stringBuilder.ToString();

        public void ClearLog() => _stringBuilder.Clear();
    }
}