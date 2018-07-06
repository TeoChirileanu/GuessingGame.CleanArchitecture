using GuessingGame.Shared.Properties;
using Moq;
using Xunit;

namespace GuessingGame.BusinessRules.Tests {
    public class GameTests {
        private readonly Mock<ILogger> _loggerMock = new Mock<ILogger>().SetupAllProperties();
        private readonly Mock<IMessenger> _messengerMock = new Mock<IMessenger>().SetupAllProperties();
        private int CorrectNumber { get; set; }

        [Fact]
        public void Check_Correct_CorrectMessage() {
            // Arrange
            CorrectNumber = GameService.GetRandomNumber();
            IGame game = new Game(_messengerMock.Object, _loggerMock.Object) {
                CorrectNumber = CorrectNumber
            };
            // Act
            game.Check(CorrectNumber);
            // Assert
            _loggerMock.Verify(l => l.Log(It.Is<string>(s => s.Contains(Resources.CorrectMessage))));
            _messengerMock.Verify(m => m.Deliver(Resources.CorrectMessage));
            Assert.True(game.IsOver);
        }

        [Fact]
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
            _loggerMock.Verify(l => l.Log(It.Is<string>(s => s.Contains(Resources.TooHighMessage))));
            _messengerMock.Verify(m => m.Deliver(Resources.TooHighMessage));
        }

        [Fact]
        public void Check_HigherThanUpperBound_InvalidNumberMessage() {
            // Arrange
            IGame game = new Game(_messengerMock.Object, _loggerMock.Object);
            int number = GameService.UpperBound + GameService.GetRandomNumber();
            // Act
            game.Check(number);
            // Assert
            _loggerMock.Verify(l => l.Log(It.Is<string>(s => s.Contains(Resources.InvalidNumberMessage))));
            _messengerMock.Verify(m => m.Deliver(Resources.InvalidNumberMessage));
        }

        [Fact]
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
            _loggerMock.Verify(l => l.Log(It.Is<string>(s => s.Contains(Resources.TooLowMessage))));
            _messengerMock.Verify(m => m.Deliver(Resources.TooLowMessage));
        }

        [Fact]
        public void Check_LowerThanLowerBound_InvalidNumberMessage() {
            // Arrange
            IGame game = new Game(_messengerMock.Object, _loggerMock.Object);
            int number = GameService.LowerBound - GameService.GetRandomNumber();
            // Act
            game.Check(number);
            // Assert
            _loggerMock.Verify(l => l.Log(It.Is<string>(s => s.Contains(Resources.InvalidNumberMessage))));
            _messengerMock.Verify(m => m.Deliver(Resources.InvalidNumberMessage));
        }

        [Fact]
        public void ShowPreviousAttempts_Called_GetLogCalled() {
            // Arrange
            _loggerMock.Setup(l => l.GetLog()).Returns(() => string.Empty);
            IGame game = new Game(_messengerMock.Object, _loggerMock.Object) {
                CorrectNumber = 50
            };
            // Act
            game.ShowPreviousAttempts();
            // Assert
            _messengerMock.Verify(l => l.Deliver(Resources.PreviousAttemptsMessage));
            _messengerMock.Verify(l => l.Deliver(string.Empty));
            _loggerMock.Verify(l => l.GetLog());
            _loggerMock.Verify(l => l.ClearLog());
        }
    }
}