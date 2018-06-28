using System;
using System.IO;
using GuessingGame.BusinessRules;
using GuessingGame.Shared;
using GuessingGame.Shared.Properties;
using MongoDB.Driver;

namespace GuessingGame.Gui.ConsoleApplication {
    public class MongoLogger : ILogger {
        private readonly string _pathToFile = Path.Combine(Resources.GameDirectory, "log.mongo");
        private string FullPathToFile => Environment.ExpandEnvironmentVariables(_pathToFile);

        public MongoLogger() {
            var client = new MongoClient();
            var database = client.GetDatabase("GuessingGame");
            LogCollection = database.GetCollection<NoSqlLog>("Logs");
        }

        private IMongoCollection<NoSqlLog> LogCollection { get; }

        public void Log(string message) {
            LogCollection.InsertOne(new NoSqlLog
            {
                TimeStamp = DateTime.Now,
                Message = message
            });
        }

        public string GetLog() {
            var logs = LogCollection.Find(FilterDefinition<NoSqlLog>.Empty).ToList();
            return string.Join("\n", logs);
        }

        public void ClearLog() {
            LogCollection.DeleteMany(FilterDefinition<NoSqlLog>.Empty);
        }
    }
}