using System;
using System.Text;
using GuessingGame.BusinessRules;
using GuessingGame.Shared;

namespace GuessingGame.Adapters {
    public class StringBuilderLogger : ILogger {
        private readonly StringBuilder _stringBuilder = new StringBuilder($"{DateTime.Now}\tLog started\n");

        public void Log(string message) => _stringBuilder.AppendLine(new Log {
            TimeStamp = DateTime.Now,
            Message = message
        }.ToString());

        public string GetLog() => _stringBuilder.ToString();

        public void ClearLog() => _stringBuilder.Clear();
    }
}