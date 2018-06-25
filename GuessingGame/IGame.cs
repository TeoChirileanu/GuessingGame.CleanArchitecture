namespace GuessingGame.BusinessRules {
    public interface IGame {
        bool IsOver { get; }
        void Check(int number);
    }
}