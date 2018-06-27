namespace GuessingGame.BusinessRules {
    public class GameController {
        private readonly IGame _game;
        private readonly INumberGetter _numberGetter;

        public GameController(IGame game, INumberGetter numberGetter) {
            _game = game;
            _numberGetter = numberGetter;
        }

        public int GetNumber() => _numberGetter.GetNumber();

        public void CheckNumber(int number) => _game.Check(number);

        public bool IsGameOver() => _game.IsOver;

        public void ShowPreviousAttempts() => _game.ShowPreviousAttempts();
    }
}