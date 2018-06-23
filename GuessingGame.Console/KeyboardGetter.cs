using System;
using GuessingGame.Properties;

namespace GuessingGame.ConsoleApplication {
    public class KeyboardGetter : INumberGetter {
        private static readonly string MessageForTheUser =
            string.Format(Resources.AskForANumber, Resources.MinValue, Resources.MaxValue);

        public int GetNumber() {
            bool parsedSuccessfully;
            int number;
            do {
                Console.WriteLine(MessageForTheUser);
                string input = Console.ReadLine();
                parsedSuccessfully = int.TryParse(input, out number);
            } while (!parsedSuccessfully);

            return number;
        }
    }
}