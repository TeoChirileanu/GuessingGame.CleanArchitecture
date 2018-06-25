using System;
using GuessingGame.Shared.Properties;

namespace GuessingGame.BusinessRules {
    public class Game : IGame {
        private readonly IMessenger _messenger;

        public Game(IMessenger messenger) {
            _messenger = messenger;
        }

        public int CorrectNumber { private get; set; } = GameService.GetRandomNumber();

        public bool IsOver { get; private set; }

        public void Check(int number) {
            if (!IsValid(number)) {
                _messenger.Deliver(Resources.InvalidNumberMessage);
                return;
            }

            switch (number.CompareTo(CorrectNumber)) {
                case 1:
                    _messenger.Deliver(Resources.TooHighMessage);
                    break;
                case -1:
                    _messenger.Deliver(Resources.TooLowMessage);
                    break;
                case 0:
                    _messenger.Deliver(Resources.CorrectMessage);
                    IsOver = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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