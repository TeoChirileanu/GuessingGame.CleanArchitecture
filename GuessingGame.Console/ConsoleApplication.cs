using System;
using GuessingGame.Adapters;
using GuessingGame.BusinessRules;
using GuessingGame.Shared.Properties;

namespace GuessingGame.Gui.ConsoleApplication {
    public class ConsoleApplication {
        private static void Main() {
            try {
                PlayGame();
            }
            catch (Exception e) {
                Console.WriteLine(Resources.GameOverMessage + e);
            }
        }

        private static void PlayGame() {
            Console.WriteLine(Resources.WelcomeMessage);
            var controller = new GameController(
                new Game(new ConsoleMessenger(), new InMemoryLogger()), new KeyboardGetter());
            do {
                int number = controller.GetNumber();
                controller.CheckNumber(number);
            } while (!controller.IsGameOver());

            Console.WriteLine(Resources.PreviousAttemptsMessage);
            controller.ShowPreviousAttempts();
        }
    }
}