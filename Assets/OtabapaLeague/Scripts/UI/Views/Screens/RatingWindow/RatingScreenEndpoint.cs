using OtabapaLeague.Scripts.Domain.Systems.Players;

namespace OtabapaLeague.Application.UI.Screens.RatingWindow
{
    public class RatingScreenEndpoint : LoaderEndpoint<RatingScreenView>, IRatingScreenEndpoint
    {
        protected override string ViewPath => "p_ui_rating";
        
        private readonly IPlayerManager _playerManager;

        public RatingScreenEndpoint(IUIHolder uiHolder, IPlayerManager playerManager) : base(uiHolder)
        {
            _playerManager = playerManager;
        }

        protected override void InitView()
        {
            var presenter = new RatingScreenPresenter(_playerManager);
            presenter.SetView(View);
        }
    }
}