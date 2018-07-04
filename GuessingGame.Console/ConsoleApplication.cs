using System;
using GuessingGame.Adapters;
using GuessingGame.BusinessRules;
using GuessingGame.Shared.Properties;

namespace GuessingGame.Gui.ConsoleApplication {
    public class ConsoleApplication {
        private static void Main() {
            try {
                Play();
            }
            catch (Exception e) {
                Console.WriteLine(Resources.GameOverMessage + e);
            }
        }

        private static void Play() {
            Console.WriteLine(Resources.WelcomeMessage);
            var controller = new GameController(new Game(new ConsoleMessenger(), new MongoLogger()){CorrectNumber = 50}, new KeyboardGetter());
            do {
                int number = controller.GetNumber();
                controller.CheckNumber(number);
            } while (!controller.IsGameOver());

            controller.ShowPreviousAttempts();
        }
    }
}