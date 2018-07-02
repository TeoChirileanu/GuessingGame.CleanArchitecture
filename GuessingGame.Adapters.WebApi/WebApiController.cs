using GuessingGame.BusinessRules;
using GuessingGame.Shared;
using Microsoft.AspNetCore.Mvc;

namespace GuessingGame.Adapters.WebApi {
    [Route("api")]
    public class WebApiController : Controller {
        private readonly IGame _game;
        private readonly IReader _reader;

        public WebApiController(IGame game, IReader reader) {
            _game = game;
            _reader = reader;
        }

        [HttpGet("[action]")]
        public ActionResult CheckNumber([FromQuery] int number) {
            _game.Check(number);
            string message = _reader.Read();
            return Ok(new GameResponse { Content = message });
        }

        [HttpGet("[action]")]
        public ActionResult ShowLogs() {
            _game.ShowPreviousAttempts();
            string message = _reader.Read();
            return Ok(new GameResponse { Content = message });
        }
    }
}