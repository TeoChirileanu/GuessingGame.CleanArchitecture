using GuessingGame.Shared.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GuessingGame.BusinessRules.Tests {
    [TestClass]
    public class GameTests {
        private readonly Mock<ILogger> _loggerMock = new Mock<ILogger>();
        private readonly Mock<IMessenger> _messengerMock = new Mock<IMessenger>();
        private int CorrectNumber { get; set; }

        [TestMethod]
        public void Check_LowerThanCorrect_TooLowMessage() {
            // Arrange
            CorrectNumber = GameService.GetRandomNumber();
            IGame game = new Game(_messengerMock.Object, _loggerMock.Object) {
                CorrectNumber = CorrectNumber
            };
            int number = GameService.GetRandomNumber(CorrectNumber);
            // Act
            game.Check(number);
            // Assert
            _loggerMock.Verify(l => l.Log(Resources.TooLowMessage));
            _messengerMock.Verify(m => m.Deliver(Resources.TooLowMessage));
        }

        [TestMethod]
        public void Check_HigherThanCorrect_TooHighMessage() {
            // Arrange
            CorrectNumber = GameService.GetRandomNumber();
            IGame game = new Game(_messengerMock.Object, _loggerMock.Object) {
                CorrectNumber = CorrectNumber
            };
            int number = GameService.GetRandomNumber(CorrectNumber + 1, GameService.UpperBound);
            // Act
            game.Check(number);
            // Assert
            _loggerMock.Verify(l => l.Log(Resources.TooHighMessage));
            _messengerMock.Verify(m => m.Deliver(Resources.TooHighMessage));
        }

        [TestMethod]
        public void Check_Correct_CorrectMessage() {
            // Arrange
            CorrectNumber = GameService.GetRandomNumber();
            IGame game = new Game(_messengerMock.Object, _loggerMock.Object) {
                CorrectNumber = CorrectNumber
            };
            // Act
            game.Check(CorrectNumber);
            // Assert
            _loggerMock.Verify(l => l.Log(Resources.CorrectMessage));
            _messengerMock.Verify(m => m.Deliver(Resources.CorrectMessage));
        }

        [TestMethod]
        public void Check_LowerThanLowerBound_InvalidNumberMessage() {
            // Arrange
            IGame game = new Game(_messengerMock.Object, _loggerMock.Object);
            int number = GameService.LowerBound - GameService.GetRandomNumber();
            // Act
            game.Check(number);
            // Assert
            _loggerMock.Verify(l => l.Log(Resources.InvalidNumberMessage));
            _messengerMock.Verify(m => m.Deliver(Resources.InvalidNumberMessage));
        }

        [TestMethod]
        public void Check_HigherThanUpperBound_InvalidNumberMessage() {
            // Arrange
            IGame game = new Game(_messengerMock.Object, _loggerMock.Object);
            int number = GameService.UpperBound + GameService.GetRandomNumber();
            // Act
            game.Check(number);
            // Assert
            _loggerMock.Verify(l => l.Log(Resources.InvalidNumberMessage));
            _messengerMock.Verify(m => m.Deliver(Resources.InvalidNumberMessage));
        }

        [TestMethod]
        public void ShowPreviousAttempts_Called_GetLogCalled() {
            // Arrange
            IGame game = new Game(_messengerMock.Object, _loggerMock.Object);
            // Act
            game.ShowPreviousAttempts();
            // Assert
            _loggerMock.Verify(l => l.GetLog());
        }
    }
}