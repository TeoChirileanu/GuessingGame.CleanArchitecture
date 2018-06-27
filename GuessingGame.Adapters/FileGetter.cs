using System;
using System.IO;
using GuessingGame.BusinessRules;
using GuessingGame.Shared.Properties;

namespace GuessingGame.Adapters {
    public class FileGetter : INumberGetter {
        private readonly string _pathToFile = Path.Combine(Resources.GameDirectory, "number.in");
        private string FullPathToFile => Environment.ExpandEnvironmentVariables(_pathToFile);

        public int GetNumber() {
            bool parsedSuccessfully;
            int parsedNumber;
            do {
                Console.WriteLine(Resources.FileGetterMessage);
                Console.ReadKey();
                string content = ReadFromFile();
                parsedSuccessfully = int.TryParse(content, out parsedNumber);
            } while (!parsedSuccessfully);

            return parsedNumber;
        }

        private string ReadFromFile() {
            using (var stream = new StreamReader(FullPathToFile)) {
                return stream.ReadToEnd();
            }
        }
    }
}