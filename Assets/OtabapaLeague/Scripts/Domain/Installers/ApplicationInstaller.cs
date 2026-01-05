using OtabapaLeague.Domain.SceneLoader;
using OtabapaLeague.Scripts.Domain.UIController;
using Zenject;

namespace OtabapaLeague.Scripts.Installers
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IUIHolder>().To<UIHolder>().AsSingle();
        }
    }
}