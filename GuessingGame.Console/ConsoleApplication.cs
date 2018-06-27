using System;
using GuessingGame.Adapters;
using GuessingGame.BusinessRules;
using GuessingGame.Shared.Properties;

namespace GuessingGame.Gui.ConsoleApplication {
    public class ConsoleApplication {
        private static void Main() {
            IGame game = new Game(new ConsoleMessenger(), new FileLogger());
            try {
                Play(game);
            }
            catch (Exception e) {
                Console.WriteLine(Resources.GameOverMessage + e);
            }
        }

        private static void Play(IGame game) {
            Console.WriteLine(Resources.WelcomeMessage);
            var controller = new GameController(game, new FileGetter());
            do {
                int number = controller.GetNumber();
                controller.CheckNumber(number);
            } while (!controller.IsGameOver());

            controller.ShowPreviousAttempts();
        }
    }
}