using System;
using GuessingGame.BusinessRules;
using GuessingGame.Shared.Properties;

namespace GuessingGame.Adapters {
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