using OtabapaLeague.Scripts.UI.UIControllers.MainController;
using OtabapaLeague.Scripts.UI.Views.Screens.MainMenuScreen;
using Zenject;

namespace OtabapaLeague.Scripts.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMainUIController>().To<MainUIController>().AsSingle();
            Container.Bind<IMainMenuEndpoint>().To<MainMenuEndpoint>().AsTransient();
        }
    }
}