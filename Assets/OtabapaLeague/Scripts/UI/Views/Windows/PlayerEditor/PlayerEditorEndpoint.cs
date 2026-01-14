using Cysharp.Threading.Tasks;
using OtabapaLeague.Scripts.Domain.Systems.Players;

namespace OtabapaLeague.Application.UI.Windows
{
    public class PlayerEditorEndpoint : ArgsLoaderEndpoint<PlayerEditorWindowArgs, PlayerEditorView>, IPlayerEditorEndpoint
    {
        protected override string ViewPath => "p_ui_player_editor";
        
        private readonly IPlayerManager _playerManager;

        public PlayerEditorEndpoint(IUIHolder uiHolder, IPlayerManager playerManager) : base(uiHolder)
        {
            _playerManager = playerManager;
        }

        protected override void InitView(PlayerEditorWindowArgs args)
        {
            var presenter = new PlayerEditorPresenter(args.Tag, args.EditCallback, _playerManager);
            presenter.SetView(View);
        }
    }
}