using OtabapaLeague.Application.UI;
using OtabapaLeague.Data.Player;
using OtabapaLeague.Data.Systems;
using OtabapaLeague.Domain.Systems.DataSerializer;
using OtabapaLeague.Scripts.Domain.Systems.Players;
using Zenject;

namespace OtabapaLeague.Domain.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IUIHolder>().To<UIHolder>().AsSingle();

            Container.Bind<IDataSerializer>().To<JsonDataSerializer>().AsSingle();
            Container.Bind<IDataSaver>().To<PlayerPrefsDataSaver>().AsSingle();
            Container.Bind<IPlayersRepository>().To<PlayerRepository>().AsSingle();
            Container.Bind<IPlayerManager>().To<PlayerManager>().AsSingle();
        }
    }
}