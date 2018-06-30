using GuessingGame.BusinessRules;
using Microsoft.AspNetCore.Mvc;

namespace GuessingGame.Adapters.WebApi {
    [Route("api/")]
    [ApiController]
    public class WebApiGetterController : ControllerBase {
        private readonly IGame _game;

        public WebApiGetterController(IGame game) => _game = game;

        [HttpGet]
        public ActionResult CheckNumber([FromQuery] int number) {
            _game.Check(number);
            return Ok();
        }
    }
}