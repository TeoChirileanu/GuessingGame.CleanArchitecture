using System;

namespace GuessingGame.Shared {
    public class Log {
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }

        public override string ToString() {
            return $"{TimeStamp}\t{Message}";
        }
    }
}