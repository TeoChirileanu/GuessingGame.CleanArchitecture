using GuessingGame.BusinessRules;
using Microsoft.AspNetCore.Mvc;

namespace GuessingGame.Adapters.WebApi {
    [Route("api/")]
    [ApiController]
    public class NumberGetterController : ControllerBase {
        [HttpGet]
        public ActionResult CheckNumber([FromQuery] int number, [FromServices] IMessenger messenger) {
            IGame game = new Game(messenger);
            game.Check(number);
            return Ok();
        }
    }
}