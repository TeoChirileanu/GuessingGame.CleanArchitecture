using System;
using System.IO;
using GuessingGame.BusinessRules;
using GuessingGame.Shared;
using GuessingGame.Shared.Properties;

namespace GuessingGame.Adapters {
    public class FileLogger : ILogger {
        private readonly string _pathToFile = Path.Combine(Resources.GameDirectory, "number.log");
        private string FullPathToFile => Environment.ExpandEnvironmentVariables(_pathToFile);

        public void Log(string message) {
            using (var stream = new StreamWriter(FullPathToFile, true)) {
                stream.WriteLine(new Log {
                    TimeStamp = DateTime.Now,
                    Message = message
                });
            }
        }

        public string GetLog() {
            using (var stream = new StreamReader(FullPathToFile)) {
                return stream.ReadToEnd();
            }
        }

        public void ClearLog() {
            using (var stream = new StreamWriter(FullPathToFile)) {
                stream.Write(string.Empty);
            }
        }
    }
}