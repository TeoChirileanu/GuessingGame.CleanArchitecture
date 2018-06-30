using System;
using System.IO;
using GuessingGame.BusinessRules;
using GuessingGame.Shared.Properties;
using Microsoft.AspNetCore.Mvc;

namespace GuessingGame.Gui.Blazor.Server.Controllers {
    [Route("api/[controller]")]
    public class GameController : Controller {
        private readonly IGame _game;
        public GameController(IGame game) => _game = game;
        //add _reader and implement FileReader

        [HttpGet("[action]")]
        public ActionResult CheckNumber([FromQuery] int number) {
            _game.Check(number);
            string message = ReadContent(Resources.OutputFile);
            return message.Contains("correct", StringComparison.OrdinalIgnoreCase)
                       ? Ok(message)
                       : StatusCode(303, message);
        }

        [HttpGet("[action]")]
        public ActionResult ShowLogs() {
            _game.ShowPreviousAttempts();
            string message = ReadContent(Resources.OutputFile);
            return Ok(message);
        }

        private string ReadContent(string file) {
            string absolutePath =
                Environment.ExpandEnvironmentVariables(Path.Combine(Resources.GameDirectory, file));
            string content;
            try {
                content = System.IO.File.ReadAllText(absolutePath);
            }
            catch (Exception e) {
                content = e.ToString();
            }

            return content;
        }
    }
}