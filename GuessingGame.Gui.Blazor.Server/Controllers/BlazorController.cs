using GuessingGame.Adapters;
using GuessingGame.Adapters.WebApi;
using GuessingGame.BusinessRules;
using Microsoft.AspNetCore.Mvc;

namespace GuessingGame.Gui.Blazor.Server.Controllers {
    [Route("api")]
    [Produces("application/json")]
    public class BlazorController : WebApiController {
        public BlazorController(IGame game, IReader reader) : base(game, reader) { }
    }
}