using System;
using GuessingGame.Shared.Properties;

namespace GuessingGame.BusinessRules {
    public class Game : IGame {
        private readonly ILogger _logger;
        private readonly IMessenger _messenger;

        public Game(IMessenger messenger, ILogger logger) {
            _messenger = messenger;
            _logger = logger;
        }

        public int CorrectNumber { private get; set; } = GameService.GetRandomNumber();

        public bool IsOver { get; private set; }

        public void Check(int number) {
            _logger.Log($"Checking {number}...");
            if (!IsValid(number)) {
                _logger.Log(Resources.InvalidNumberMessage);
                _messenger.Deliver(Resources.InvalidNumberMessage);
                return;
            }

            switch (number.CompareTo(CorrectNumber)) {
                case 1:
                    _logger.Log($"{number} is {Resources.TooHighMessage}");
                    _messenger.Deliver(Resources.TooHighMessage);
                    break;
                case -1:
                    _logger.Log($"{number} is {Resources.TooLowMessage}");
                    _messenger.Deliver(Resources.TooLowMessage);
                    break;
                case 0:
                    _logger.Log($"{number} is {Resources.CorrectMessage}");
                    _messenger.Deliver(Resources.CorrectMessage);
                    IsOver = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ShowPreviousAttempts() {
            _messenger.Deliver(_logger.GetLog());
            _logger.ClearLog();
        }

        private bool IsValid(int number) {
            try {
                GameService.Validate(number);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }
    }
}