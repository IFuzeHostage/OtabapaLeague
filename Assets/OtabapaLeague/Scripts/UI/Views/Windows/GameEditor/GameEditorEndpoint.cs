using OtabapaLeague.Scripts.Domain.Systems.Games;
using OtabapaLeague.Scripts.Domain.Systems.Players;

namespace OtabapaLeague.Application.UI.Windows.GameEditor
{
    public class GameEditorEndpoint : ArgsLoaderEndpoint<GameEditorWindowArgs, GameEditorView>, IGameEditorEndpoint
    {
        protected override string ViewPath => "p_ui_game_editor";

        private IPlayerManager _playerManager;
        private GameEditorPresenter _presenter;

        public GameEditorEndpoint(IUIHolder uiHolder, IPlayerManager playerManager) : base(uiHolder)
        {
            _playerManager = playerManager;
        }

        protected override void InitView(GameEditorWindowArgs args)
        {
            _presenter = new GameEditorPresenter(args.OnSubmit, _playerManager);
            _presenter.SetView(View);
        }
        
        protected override void DisposeView()
        {
            _presenter.DetachView();
        }
    }
}