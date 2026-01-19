using OtabapaLeague.Application.UI.UIControllers.MainController;

namespace OtabapaLeague.Application.UI.Screens.Games
{
    public interface IGameWindowEndpoint : IViewEndpoint
    {
        void SetController(IMainUIController controller);
    }
}