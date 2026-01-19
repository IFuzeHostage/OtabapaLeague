using OtabapaLeague.Application.UI.UIControllers.MainController;
using OtabapaLeague.Scripts.Domain.Systems.Games;
using OtabapaLeague.Scripts.Domain.Systems.Players;

namespace OtabapaLeague.Application.UI.Screens.Games
{
    public class GameWindowEndpoint : LoaderEndpoint<GamesWindowView>, IGameWindowEndpoint
    {
        protected override string ViewPath => "p_ui_games";
        
        private IMainUIController _mainUIController;
        private IGamesManager _gamesManager;
        private IPlayerManager _playerManager;
        
        public GameWindowEndpoint(IUIHolder uiHolder, IGamesManager gamesManager, IPlayerManager playerManager) : base(uiHolder)
        {
            _gamesManager = gamesManager;
            _playerManager = playerManager;
        }

        protected override void InitView()
        {
            var presenter = new GameWindowPresenter(_gamesManager, _playerManager, _mainUIController);
            presenter.SetView(View);
        }

        public void SetController(IMainUIController controller)
        {
            _mainUIController = controller;
        }
    }
}