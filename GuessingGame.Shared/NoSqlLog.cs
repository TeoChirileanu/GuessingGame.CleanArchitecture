using MongoDB.Bson;

namespace GuessingGame.Shared {
    public class NoSqlLog : Log {
        public ObjectId Id { get; set; }
    }
}