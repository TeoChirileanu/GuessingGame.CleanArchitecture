using System;
using GuessingGame.Properties;

namespace GuessingGame.ConsoleApplication {
    public class ConsoleApplication {
        private static void Main() {
            PlayGame();
        }

        private static void PlayGame() {
            Console.WriteLine(Resources.WelcomeMessage);
            var controller = new GameController(new Game(new ConsoleMessenger()), new KeyboardGetter());
            do {
                int number = controller.GetNumber();
                controller.CheckNumber(number);
            } while (!controller.IsGameOver());
        }
    }
}