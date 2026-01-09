using OtabapaLeague.Scripts.Domain.UIController;
using Zenject;

namespace OtabapaLeague.Scripts.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IUIHolder>().To<UIHolder>().AsSingle();
        }
    }
}