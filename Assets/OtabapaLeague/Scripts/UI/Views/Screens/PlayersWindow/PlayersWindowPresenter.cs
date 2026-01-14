using OtabapaLeague.Application.UI.Windows;
using OtabapaLeague.Scripts.Domain.Systems.Players;

namespace OtabapaLeague.Application.UI.Screens.PlayersWindow
{
    public class PlayersWindowPresenter : ViewPresenter<PlayersWindowView>
    {
        private readonly IPlayerManager _playerManager;
        private readonly IMainUIController _mainUIController;
        
        public PlayersWindowPresenter(IPlayerManager playerManager, IMainUIController mainUIController)
        {
            _playerManager = playerManager;
            _mainUIController = mainUIController;
        }
        
        public override void OnViewReady()
        {
            View.OnAddPlayerClicked += OnAddPlayerClicked;
            
            foreach (var player in _playerManager.AllPlayers)
            {
                View.AddPlayer(player.Name, player.Tag, player.Score);   
            }
        }

        public override void OnViewDisabled()
        {
            
        }

        private void OnAddPlayerClicked()
        {
            _mainUIController.OpenAddPlayerEditor(OnAddPlayerSubmit);
        }

        //TODO this shouldnt be here
        private void OnAddPlayerSubmit(PlayerEditSubmitEventArgs onSubmitArgs)
        {
            _playerManager.AddNewPlayer(onSubmitArgs.Name, onSubmitArgs.Tag);
        }
    }
}