using GuessingGame.Adapters;
using GuessingGame.Adapters.WebApi;
using GuessingGame.BusinessRules;

namespace GuessingGame.Gui.Angular.Controllers {
    public class AngularController : WebApiController {
        public AngularController(IGame game, IReader reader) : base(game, reader) { }
    }
}