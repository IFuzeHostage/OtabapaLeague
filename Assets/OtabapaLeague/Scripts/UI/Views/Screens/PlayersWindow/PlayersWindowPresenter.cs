using OtabapaLeague.Application.UI.Windows;
using OtabapaLeague.Data.Player;
using OtabapaLeague.Scripts.Domain.Systems.Players;

namespace OtabapaLeague.Application.UI.Screens.PlayersWindow
{
    public class PlayersWindowPresenter : ViewPresenter<PlayersWindowView>
    {
        private readonly IPlayerManager _playerManager;
        private readonly IMainUIController _mainUIController;
        
        private PlayerModel _editedPlayerModel = null;
        
        public PlayersWindowPresenter(IPlayerManager playerManager, IMainUIController mainUIController)
        {
            _playerManager = playerManager;
            _mainUIController = mainUIController;
        }
        
        public override void OnViewReady()
        {
            _playerManager.OnPlayerAdded += OnPlayerAdded;
            _playerManager.OnPlayerRemoved += OnPlayerRemoved;
            _playerManager.OnPlayerUpdated += OnUpdatePlayer;
            View.OnAddPlayerClicked += OnAddPlayerClicked;
            
            DrawPlayerList();
        }

        public override void OnViewDisabled()
        {
            
        }

        private void DrawPlayerList()
        {
            View.ClearPlayers();
            foreach (var player in _playerManager.AllPlayers)
            {
                var playerView = View.AddPlayer(player.Name, player.Tag, player.Score);
                playerView.OnEditButton += () => ProcessEditPlayer(player);
                playerView.OnDeleteButton += () => ProcessDeletePlayer(player);
            }
        }

        private void OnAddPlayerClicked()
        {
            _mainUIController.OpenAddPlayerEditor(OnAddPlayerSubmit);
        }
        
        private void OnAddPlayerSubmit(PlayerEditSubmitEventArgs onSubmitArgs)
        {
            _playerManager.AddNewPlayer(onSubmitArgs.Name, onSubmitArgs.Tag);
        }

        private void OnEditPlayerSubmit(PlayerEditSubmitEventArgs onSubmitArgs)
        {
            if (_playerManager.TryGetPlayer(_editedPlayerModel.Id, out var player))
            {
                player.UpdateName(onSubmitArgs.Name);
                player.UpdateTag(onSubmitArgs.Tag);
                player.UpdateScore(onSubmitArgs.Score);
                
                _playerManager.UpdatePlayer(player);
            }
        }
        
        private void OnPlayerAdded(PlayerModel playerModel)
        {
            DrawPlayerList();
        }

        private void OnUpdatePlayer(PlayerModel playerModel)
        {
            DrawPlayerList();
        }
        
        private void OnPlayerRemoved(PlayerModel playerModel)
        {
            DrawPlayerList();
        }
        
        private void ProcessEditPlayer(PlayerModel playerModel)
        {
            _editedPlayerModel = playerModel;
            _mainUIController.OpenPlayerEditor(playerModel.Id, OnEditPlayerSubmit);
        }

        private void ProcessDeletePlayer(PlayerModel playerModel)
        {
            _playerManager.RemovePlayer(playerModel.Id);
        }
    }
}