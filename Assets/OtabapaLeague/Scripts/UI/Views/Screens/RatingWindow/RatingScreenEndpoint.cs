using OtabapaLeague.Scripts.Data.AvatarsRepository;
using OtabapaLeague.Scripts.Domain.Systems.Players;

namespace OtabapaLeague.Application.UI.Screens.RatingWindow
{
    public class RatingScreenEndpoint : LoaderEndpoint<RatingScreenView>, IRatingScreenEndpoint
    {
        protected override string ViewPath => "p_ui_rating";
        
        private readonly IPlayerManager _playerManager;
        private readonly IPlayerAvatarsRepository _playerAvatarsRepository;

        protected RatingScreenPresenter _presenter;
        
        public RatingScreenEndpoint(IUIHolder uiHolder, IPlayerManager playerManager, 
            IPlayerAvatarsRepository playerAvatarsRepository) : base(uiHolder)
        {
            _playerManager = playerManager;
            _playerAvatarsRepository = playerAvatarsRepository;
        }

        protected override void InitView()
        {
            _presenter = new RatingScreenPresenter(_playerManager, _playerAvatarsRepository);
            _presenter.SetView(View);
        }
        
        protected override void DisposeView()
        {
            _presenter.DetachView();
        }
    }
}