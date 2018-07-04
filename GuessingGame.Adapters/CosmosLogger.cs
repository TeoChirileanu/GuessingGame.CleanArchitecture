using System;
using GuessingGame.BusinessRules;
using GuessingGame.Shared;
using static GuessingGame.Adapters.CosmosRepository<GuessingGame.Shared.Log>;

namespace GuessingGame.Adapters {
    public class CosmosLogger : ILogger {
        public void Log(string message) {
#pragma warning disable 4014
            StoreLog(new Log {
                TimeStamp = DateTime.Now,
                Message = message
            });
        }

        public string GetLog() {
            var logs = GetLogs();
            return string.Join("\n", logs);
        }

        public void ClearLog() {
            DeleteLogs();
#pragma warning restore 4014
        }
    }
}