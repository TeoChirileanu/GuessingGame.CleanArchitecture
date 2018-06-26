using System;
using System.IO;
using GuessingGame.BusinessRules;
using GuessingGame.Shared.Properties;

namespace GuessingGame.Adapters {
    public class FileGetter : INumberGetter {
        private readonly string _file =
            Environment.ExpandEnvironmentVariables(@"%temp%\guessinggame\number.in");

        public int GetNumber() {
            Console.WriteLine(Resources.FileGetterMessage);
            Console.ReadKey();
            string content = ReadFromFile();
            bool parsedSuccessfully = int.TryParse(content, out int parsedNumber);
            if (!parsedSuccessfully) throw new Exception($"Parsing failed. {content} is not a valid number.");
            return parsedNumber;
        }

        private string ReadFromFile() {
            string content;
            try {
                content = File.ReadAllText(_file);
            }
            catch (Exception e) {
                throw new Exception($"Could not read from file {_file}", e);
            }

            return content;
        }
    }
}