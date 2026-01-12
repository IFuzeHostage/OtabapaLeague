using OtabapaLeague.Application.UI;
using OtabapaLeague.Application.UI.Screens.MainMenuScreen;
using OtabapaLeague.Application.UI.Screens.PlayersWindow;
using OtabapaLeague.Application.UI.UIControllers.MainController;
using Zenject;

namespace OtabapaLeague.Domain.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMainUIController>().To<MainUIController>().AsSingle();
            
            Container.Bind<IMainMenuEndpoint>().To<MainMenuEndpoint>().AsTransient();
            Container.Bind<IPlayersWindowEndpoint>().To<PlayersWindowEndpoint>().AsTransient();
        }
    }
}