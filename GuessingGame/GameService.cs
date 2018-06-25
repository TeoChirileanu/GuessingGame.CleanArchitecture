using System;
using GuessingGame.Shared.Properties;

namespace GuessingGame.BusinessRules {
    public static class GameService {
        private static Random Random => new Random();
        public static int LowerBound => int.Parse(Resources.MinValue);
        public static int UpperBound => int.Parse(Resources.MaxValue);

        public static int GetRandomNumber() => Random.Next(LowerBound, UpperBound);

        public static int GetRandomNumber(int upperBound) => Random.Next(upperBound);

        public static int GetRandomNumber(int lowerBound, int upperBound) =>
            Random.Next(lowerBound, upperBound);

        public static void Validate(int number) {
            if (number < LowerBound || number > UpperBound)
                throw new ArgumentOutOfRangeException(nameof(number));
        }
    }
}