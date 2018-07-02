using System;
using System.IO;
using GuessingGame.Shared.Properties;

namespace GuessingGame.Adapters {
    public class FileReader : IReader {
        public string Read() {
            string absolutePath =
                Environment.ExpandEnvironmentVariables(
                    Path.Combine(Resources.GameDirectory, Resources.OutputFile));
            string content;
            try {
                content = File.ReadAllText(absolutePath);
            }
            catch (Exception e) {
                content = e.ToString();
            }

            return content;
        }
    }
}