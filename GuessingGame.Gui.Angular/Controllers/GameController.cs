using System;
using GuessingGame.Adapters;
using GuessingGame.BusinessRules;
using GuessingGame.Shared.Properties;
using Microsoft.AspNetCore.Mvc;

namespace GuessingGame.Gui.Angular.Controllers {
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
            return message.Contains("correct", StringComparison.OrdinalIgnoreCase)
                       ? Ok(message)
                       : StatusCode(303, message);
        }

        [HttpGet("[action]")]
        public ActionResult ShowLogs() {
            string message = _reader.Read(Resources.LogFile);
            return Ok(message);
        }
    }
}