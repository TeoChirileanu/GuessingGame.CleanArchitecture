using System;
using GuessingGame.Properties;

namespace GuessingGame.ConsoleApplication {
    public class ConsoleApplication {
        private static void Main() {

            try {
                PlayGame();
            }
            catch (Exception e) {
                Console.WriteLine(Properties.Resources.GameOverMessage + e.Message);
            }
        }

        private static void PlayGame() {
            Console.WriteLine(Resources.WelcomeMessage);
            var controller = new GameController(new Game(new SmsMessenger()), new KeyboardGetter());
            do {
                int number = controller.GetNumber();
                controller.CheckNumber(number);
            } while (!controller.IsGameOver());
        }
    }
}