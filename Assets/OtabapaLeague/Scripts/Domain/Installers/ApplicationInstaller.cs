using OtabapaLeague.Application.SceneLoader;
using OtabapaLeague.Data.Settings;
using Zenject;

namespace OtabapaLeague.Domain.Installers
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