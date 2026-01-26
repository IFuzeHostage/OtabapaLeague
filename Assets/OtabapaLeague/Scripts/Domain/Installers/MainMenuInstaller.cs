using OtabapaLeague.Application.UI;
using OtabapaLeague.Application.UI.Screens.Games;
using OtabapaLeague.Application.UI.Screens.MainMenuScreen;
using OtabapaLeague.Application.UI.Screens.PlayersWindow;
using OtabapaLeague.Application.UI.Screens.RatingWindow;
using OtabapaLeague.Application.UI.UIControllers.MainController;
using OtabapaLeague.Application.UI.Windows;
using OtabapaLeague.Application.UI.Windows.GameEditor;
using OtabapaLeague.Scripts.Domain.Systems.Files;
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
            Container.Bind<IPlayerEditorEndpoint>().To<PlayerEditorEndpoint>().AsTransient();
            Container.Bind<IGameWindowEndpoint>().To<GameWindowEndpoint>().AsTransient();
            Container.Bind<IGameEditorEndpoint>().To<GameEditorEndpoint>().AsTransient();
            Container.Bind<IRatingScreenEndpoint>().To<RatingScreenEndpoint>().AsTransient();
        }
    }
}