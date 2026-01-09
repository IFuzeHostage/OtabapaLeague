using Cysharp.Threading.Tasks;
using OtabapaLeague.Scripts.UI.Views.Screens.MainMenuScreen;

namespace OtabapaLeague.Scripts.UI.UIControllers.MainController
{
    public class MainUIController : IMainUIController
    {
        private readonly IMainMenuEndpoint _mainMenuEndpoint;
        
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
    }
}