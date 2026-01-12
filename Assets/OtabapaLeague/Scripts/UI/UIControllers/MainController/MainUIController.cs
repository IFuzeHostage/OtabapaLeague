using Cysharp.Threading.Tasks;
using OtabapaLeague.Application.UI.Screens.MainMenuScreen;
using OtabapaLeague.Application.UI.Screens.PlayersWindow;

namespace OtabapaLeague.Application.UI.UIControllers.MainController
{
    public class MainUIController : IMainUIController
    {
        private readonly IMainMenuEndpoint _mainMenuEndpoint;
        private readonly IPlayersWindowEndpoint _playersWindowEndpoint;
        
        public MainUIController(IMainMenuEndpoint mainMenuEndpoint)
        {
            _mainMenuEndpoint = mainMenuEndpoint;
        }
        
        public async UniTask OpenMainMenu()
        {
            await _mainMenuEndpoint.Open();
        }

        public async UniTask CloseMainMenu()
        {
            await _mainMenuEndpoint.Close();
        }

        public async UniTask OpenPlayersWindow()
        {
            await _playersWindowEndpoint.Open();
        }

        public async UniTask ClosePlayersWindow()
        {
            await _playersWindowEndpoint.Close();
        }
    }
}