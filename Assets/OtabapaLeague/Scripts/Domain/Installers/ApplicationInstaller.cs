using OtabapaLeague.Domain.SceneLoader;
using Zenject;

namespace OtabapaLeague.Scripts.Installers
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }
    }
}