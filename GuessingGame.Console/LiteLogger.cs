using System;
using System.IO;
using GuessingGame.BusinessRules;
using GuessingGame.Shared;
using GuessingGame.Shared.Properties;
using LiteDB;
using ObjectId = MongoDB.Bson.ObjectId;

namespace GuessingGame.Gui.ConsoleApplication {
    public class LiteLogger : ILogger {
        private readonly string _pathToFile = Path.Combine(Resources.GameDirectory, "log.lite");

        public LiteLogger() {
            using (var database = new LiteDatabase(FullPathToFile)) {
                LogCollection = database.GetCollection<NoSqlLog>("logs");
            }
        }

        private string FullPathToFile => Environment.ExpandEnvironmentVariables(_pathToFile);

        private LiteCollection<NoSqlLog> LogCollection { get; }

        public void Log(string message) {
            LogCollection.Insert(new NoSqlLog {
                Id = ObjectId.GenerateNewId(),
                TimeStamp = DateTime.Now,
                Message = message
            });
        }

        public string GetLog() {
            var logs = LogCollection.Find(Query.All());
            return string.Join("\n", logs);
        }

        public void ClearLog() {
            LogCollection.Delete(Query.All());
        }
    }
}