using GuessingGame.BusinessRules;
using Microsoft.AspNetCore.Mvc;

namespace GuessingGame.Adapters.WebApi.Controllers {
    [Route("api/")]
    [ApiController]
    public class NumberGetterController : ControllerBase {
        [HttpGet]
        public ActionResult CheckNumber([FromQuery] int number, [FromServices] IMessenger _messenger) {
            IGame game = new Game(_messenger);
            game.Check(number);
            return Ok();
        }
    }
}