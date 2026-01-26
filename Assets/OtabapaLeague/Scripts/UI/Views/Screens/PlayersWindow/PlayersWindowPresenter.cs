using OtabapaLeague.Application.UI.Windows;
using OtabapaLeague.Data.Player;
using OtabapaLeague.Scripts.Data.AvatarsRepository;
using OtabapaLeague.Scripts.Domain.Systems.Players;

namespace OtabapaLeague.Application.UI.Screens.PlayersWindow
{
    public class PlayersWindowPresenter : ViewPresenter<PlayersWindowView>
    {
        private readonly IPlayerManager _playerManager;
        private readonly IPlayerAvatarsRepository _playerAvatarsRepository;
        private readonly IMainUIController _mainUIController;
        
        private PlayerModel _editedPlayerModel = null;
        
        public PlayersWindowPresenter(IPlayerManager playerManager, IPlayerAvatarsRepository playerAvatarRepository, 
            IMainUIController mainUIController)
        {
            _playerManager = playerManager;
            _mainUIController = mainUIController;
            _playerAvatarsRepository = playerAvatarRepository;
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
            _playerManager.OnPlayerAdded -= OnPlayerAdded;
            _playerManager.OnPlayerRemoved -= OnPlayerRemoved;
            _playerManager.OnPlayerUpdated -= OnUpdatePlayer;
            View.OnAddPlayerClicked -= OnAddPlayerClicked;
        }

        private void DrawPlayerList()
        {
            View.ClearPlayers();
            foreach (var player in _playerManager.AllPlayers)
            {
                var avatar = _playerAvatarsRepository.GetAvatar(player.Id);
                var playerView = View.AddPlayer(player.Name, player.Tag, player.Rating, avatar);
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
            _playerManager.AddNewPlayer(onSubmitArgs.Name, onSubmitArgs.Tag, onSubmitArgs.Avatar);
        }

        private void OnEditPlayerSubmit(PlayerEditSubmitEventArgs onSubmitArgs)
        {
            if (_playerManager.TryGetPlayer(_editedPlayerModel.Id, out var player))
            {
                player.UpdateName(onSubmitArgs.Name);
                player.UpdateTag(onSubmitArgs.Tag);
                _playerAvatarsRepository.SaveAvatar(_editedPlayerModel.Id, onSubmitArgs.Avatar);
                
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