namespace OtabapaLeague.Application.UI.Screens.Games
{
    public class GameWindowEndpoint : LoaderEndpoint<GamesWindowView>, IGameWindowEndpoint
    {
        protected override string ViewPath => "p_ui_screen_games";
        
        public GameWindowEndpoint(IUIHolder uiHolder) : base(uiHolder)
        {
        }

        protected override void InitView()
        {
            
        }
    }
}