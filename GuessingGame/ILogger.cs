namespace GuessingGame.BusinessRules {
    public interface ILogger {
        void Log(string message);
        string GetLog();
        void ClearLog();
    }
}