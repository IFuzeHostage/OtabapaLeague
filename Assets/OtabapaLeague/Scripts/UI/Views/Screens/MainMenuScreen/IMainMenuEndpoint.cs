namespace OtabapaLeague.Application.UI.Screens.MainMenuScreen
{
    public interface IMainMenuEndpoint : IViewEndpoint
    {
        void SetController(IMainUIController mainUIController);
    }
}