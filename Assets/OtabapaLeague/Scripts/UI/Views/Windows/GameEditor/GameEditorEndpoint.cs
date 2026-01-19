using OtabapaLeague.Scripts.Domain.Systems.Games;
using OtabapaLeague.Scripts.Domain.Systems.Players;

namespace OtabapaLeague.Application.UI.Windows.GameEditor
{
    public class GameEditorEndpoint : ArgsLoaderEndpoint<GameEditorWindowArgs, GameEditorView>, IGameEditorEndpoint
    {
        protected override string ViewPath => "p_ui_game_editor";
        
        private IPlayerManager _playerManager;

        public GameEditorEndpoint(IUIHolder uiHolder, IPlayerManager playerManager) : base(uiHolder)
        {
            _playerManager = playerManager;
        }

        protected override void InitView(GameEditorWindowArgs args)
        {
            var presenter = new GameEditorPresenter(args.OnSubmit, _playerManager);
            presenter.SetView(View);
        }
    }
}