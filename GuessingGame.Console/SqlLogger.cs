using System;
using GuessingGame.BusinessRules;
using GuessingGame.Shared;

namespace GuessingGame.Gui.ConsoleApplication {
    public class SqlLogger : ILogger {
        public void Log(string message) {
            using (var context = new LogContext()) {
                context.Logs.Add(new SqlLog {
                    TimeStamp = DateTime.Now,
                    Message= message
                });
                context.SaveChanges();
            }
        }

        public string GetLog() {
            using (var context = new LogContext()) {
                return string.Join("\n", context.Logs);
            }
        }

        public void ClearLog() {
            using (var context = new LogContext()) {
                context.Logs.RemoveRange(context.Logs);
                context.SaveChanges();
            }
        }
    }
}