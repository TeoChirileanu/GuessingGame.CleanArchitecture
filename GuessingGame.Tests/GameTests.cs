using GuessingGame.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GuessingGame.Tests {
    [TestClass]
    public class GameTests {
        private readonly Mock<IMessenger> _messengerMock = new Mock<IMessenger>();

        private int CorrectNumber { get; set; }

        [TestMethod]
        public void Check_LowerThanCorrect_TooLowMessage() {
            // Arrange
            CorrectNumber = GameService.GetRandomNumber();
            IGame game = new Game(_messengerMock.Object) {
                CorrectNumber = CorrectNumber
            };
            int number = GameService.GetRandomNumber(CorrectNumber);
            // Act
            game.Check(number);
            // Assert
            _messengerMock.Verify(m => m.Deliver(Resources.TooLowMessage));
        }

        [TestMethod]
        public void Check_HigherThanCorrect_TooHighMessage() {
            // Arrange
            CorrectNumber = GameService.GetRandomNumber();
            IGame game = new Game(_messengerMock.Object) {
                CorrectNumber = CorrectNumber
            };
            int number = GameService.GetRandomNumber(CorrectNumber + 1, GameService.UpperBound);
            // Act
            game.Check(number);
            // Assert
            _messengerMock.Verify(m => m.Deliver(Resources.TooHighMessage));
        }

        [TestMethod]
        public void Check_Correct_CorrectMessage() {
            // Arrange
            CorrectNumber = GameService.GetRandomNumber();
            IGame game = new Game(_messengerMock.Object) {
                CorrectNumber = CorrectNumber
            };
            // Act
            game.Check(CorrectNumber);
            // Assert
            _messengerMock.Verify(m => m.Deliver(Resources.CorrectMessage));
        }

        [TestMethod]
        public void Check_LowerThanLowerBound_InvalidNumberMessage() {
            // Arrange
            IGame game = new Game(_messengerMock.Object);
            int number = GameService.LowerBound - GameService.GetRandomNumber();
            // Act
            game.Check(number);
            // Assert
            _messengerMock.Verify(m => m.Deliver(Resources.InvalidNumberMessage));
        }

        [TestMethod]
        public void Check_HigherThanUpperBound_InvalidNumberMessage() { }

        [TestMethod]
        public void Check_VeryLargePositiveNumber_Dunno() { }

        [TestMethod]
        public void Check_VeryLargeNegativeNumber_Dunno() { }
    }
}