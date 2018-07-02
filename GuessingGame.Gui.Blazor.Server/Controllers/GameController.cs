using System;
using GuessingGame.Adapters;
using GuessingGame.BusinessRules;
using GuessingGame.Shared.Properties;
using Microsoft.AspNetCore.Mvc;

namespace GuessingGame.Gui.Blazor.Server.Controllers {
    [Route("api/[controller]")]
    public class GameController : Controller {
        private readonly IGame _game;
        private readonly IReader _reader;

        public GameController(IGame game, IReader reader) {
            _game = game;
            _reader = reader;
        }

        [HttpGet("[action]")]
        public ActionResult CheckNumber([FromQuery] int number) {
            _game.Check(number);
            string message = _reader.Read(Resources.OutputFile);
            return Ok(message);
        }

        [HttpGet("[action]")]
        public ActionResult ShowLogs() {
            _game.ShowPreviousAttempts();
            string message = _reader.Read(Resources.OutputFile);
            return Ok(message);
        }
    }
}