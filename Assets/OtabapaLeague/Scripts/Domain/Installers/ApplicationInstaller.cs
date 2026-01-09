using OtabapaLeague.Domain.SceneLoader;
using OtabapaLeague.Domain.SettingsLoader;
using OtabapaLeague.Scripts.Domain.UIController;
using Zenject;

namespace OtabapaLeague.Scripts.Installers
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISettingsLoader>().To<SettingsLoader>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }
    }
}