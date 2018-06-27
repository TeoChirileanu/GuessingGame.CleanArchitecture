using System;

namespace GuessingGame.Shared {
    public class Log {
        public int LogId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Content { get; set; }

        public override string ToString() {
            return $"{TimeStamp}\t{Content}";
        }
    }
}