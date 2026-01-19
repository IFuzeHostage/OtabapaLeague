using System;
using Cysharp.Threading.Tasks;
using OtabapaLeague.Application.UI.Screens.Games;
using OtabapaLeague.Application.UI.Screens.MainMenuScreen;
using OtabapaLeague.Application.UI.Screens.PlayersWindow;
using OtabapaLeague.Application.UI.Windows;
using OtabapaLeague.Application.UI.Windows.GameEditor;

namespace OtabapaLeague.Application.UI.UIControllers.MainController
{
    public class MainUIController : IMainUIController
    {
        private readonly IMainMenuEndpoint _mainMenuEndpoint;
        private readonly IPlayersWindowEndpoint _playersWindowEndpoint;
        private readonly IPlayerEditorEndpoint _playerEditorEndpoint;
        private readonly IGameWindowEndpoint _gameWindowEndpoint;
        private readonly IGameEditorEndpoint _gameEditorEndpoint;
        
        public MainUIController(IMainMenuEndpoint mainMenuEndpoint, IPlayersWindowEndpoint playersWindowEndpoint,
            IPlayerEditorEndpoint playerEditorEndpoint, IGameWindowEndpoint gameWindowEndpoint,
            IGameEditorEndpoint gameEditorEndpoint)
        {
            _mainMenuEndpoint = mainMenuEndpoint;
            _playersWindowEndpoint = playersWindowEndpoint;
            _playerEditorEndpoint = playerEditorEndpoint;
            _gameWindowEndpoint = gameWindowEndpoint;
            _gameEditorEndpoint = gameEditorEndpoint;
            
            _mainMenuEndpoint.SetController(this);
            _playersWindowEndpoint.SetController(this);
            _gameWindowEndpoint.SetController(this);
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

        public async UniTask OpenAddPlayerEditor(Action<PlayerEditSubmitEventArgs> addCallback)
        {
            var args = new PlayerEditorWindowArgs(-1, addCallback);
            await _playerEditorEndpoint.Open(args);
        }

        public async UniTask OpenPlayerEditor(int playerId, Action<PlayerEditSubmitEventArgs> editCallback)
        {
            var args = new PlayerEditorWindowArgs(playerId, editCallback);
            await _playerEditorEndpoint.Open(args);
        }

        public async UniTask ClosePlayerEditor()
        {
            await _playerEditorEndpoint.Close();
        }

        public async UniTask OpenGameWindow()
        {
            await _gameWindowEndpoint.Open();
        }
        
        public async UniTask CloseGameWindow()
        {
            await _gameWindowEndpoint.Close();
        }
        
        public async UniTask OpenGameEditor(Action<GameEditorSubmitArgs> onSubmit)
        {
            await _gameEditorEndpoint.Open(new GameEditorWindowArgs(onSubmit));
        }

        public async UniTask CloseGameEditor()
        {
            await _gameEditorEndpoint.Close();
        }
    }
}