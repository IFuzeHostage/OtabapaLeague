using Cysharp.Threading.Tasks;
using OtabapaLeague.Scripts.Domain.Systems.Players;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Screens.PlayersWindow
{
    public class PlayersWindowEndpoint : LoaderEndpoint<PlayersWindowView>, IPlayersWindowEndpoint
    {
        protected override string ViewPath => "p_ui_players";
        
        private readonly IPlayerManager _playerManager;
        
        private IMainUIController _mainUIController;
        
        public PlayersWindowEndpoint(IUIHolder uiHolder, IPlayerManager playerManager) : base(uiHolder)
        {
            _playerManager = playerManager;
        }

        //TODO this is ass
        public void SetController(IMainUIController mainUIController)
        {
            _mainUIController = mainUIController;
        }
        
        protected override void InitView()
        {
            var presenter = new PlayersWindowPresenter(_playerManager, _mainUIController);
            presenter.SetView(View); 
        }
    }
}