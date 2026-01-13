using Cysharp.Threading.Tasks;

namespace OtabapaLeague.Application.UI.Windows
{
    public class PlayerEditorEndpoint : LoaderEndpoint<PlayerEditorView>, IPlayerEditorEndpoint
    {
        protected override string ViewPath => "p_ui_player_editor";

        public PlayerEditorEndpoint(IUIHolder uiHolder) : base(uiHolder)
        {
        }

        protected override void InitView()
        {
            var presenter = new PlayerEditorPresenter();
            presenter.SetView(View);
        }
    }
}