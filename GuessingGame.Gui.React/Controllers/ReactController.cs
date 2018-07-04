using GuessingGame.Adapters;
using GuessingGame.Adapters.WebApi;
using GuessingGame.BusinessRules;

namespace GuessingGame.Gui.React.Controllers {
    public class ReactController : WebApiController {
        public ReactController(IGame game, IReader reader) : base(game, reader) { }
    }
}