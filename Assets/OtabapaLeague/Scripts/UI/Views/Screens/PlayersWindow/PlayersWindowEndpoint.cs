using Cysharp.Threading.Tasks;
using OtabapaLeague.Scripts.Data.AvatarsRepository;
using OtabapaLeague.Scripts.Domain.Systems.Players;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Screens.PlayersWindow
{
    public class PlayersWindowEndpoint : LoaderEndpoint<PlayersWindowView>, IPlayersWindowEndpoint
    {
        protected override string ViewPath => "p_ui_players";
        
        private readonly IPlayerManager _playerManager;
        private readonly IPlayerAvatarsRepository _playerAvatarsRepository;
        
        private IMainUIController _mainUIController;
        private PlayersWindowPresenter _presenter;
        
        public PlayersWindowEndpoint(IUIHolder uiHolder, IPlayerManager playerManager,
            IPlayerAvatarsRepository playerAvatarsRepository) : base(uiHolder)
        {
            _playerManager = playerManager;
            _playerAvatarsRepository = playerAvatarsRepository;
        }

        //TODO this is ass
        public void SetController(IMainUIController mainUIController)
        {
            _mainUIController = mainUIController;
        }
        
        protected override void InitView()
        {
            _presenter = new PlayersWindowPresenter(_playerManager, _playerAvatarsRepository, _mainUIController);
            _presenter.SetView(View); 
        }
        
        protected override void DisposeView()
        {
            _presenter.DetachView();
        }
    }
}