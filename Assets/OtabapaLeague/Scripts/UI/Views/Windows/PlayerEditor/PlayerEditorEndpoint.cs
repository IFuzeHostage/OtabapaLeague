using Cysharp.Threading.Tasks;
using OtabapaLeague.Scripts.Data.AvatarsRepository;
using OtabapaLeague.Scripts.Domain.Systems.Players;

namespace OtabapaLeague.Application.UI.Windows
{
    public class PlayerEditorEndpoint : ArgsLoaderEndpoint<PlayerEditorWindowArgs, PlayerEditorView>, IPlayerEditorEndpoint
    {
        protected override string ViewPath => "p_ui_player_editor";

        private readonly IPlayerManager _playerManager;
        private readonly IPlayerAvatarsRepository _playerAvatarsRepository;

        private PlayerEditorPresenter _presenter;
        
        public PlayerEditorEndpoint(IUIHolder uiHolder, IPlayerManager playerManager,
            IPlayerAvatarsRepository playerAvatarsRepository) : base(uiHolder)
        {
            _playerManager = playerManager;
            _playerAvatarsRepository = playerAvatarsRepository;
        }

        protected override void InitView(PlayerEditorWindowArgs args)
        {
            _presenter = new PlayerEditorPresenter(args.Id, args.EditCallback, _playerManager, _playerAvatarsRepository);
            _presenter.SetView(View);
        }
        
        protected override void DisposeView()
        {
            _presenter.DetachView();
        }
    }
}