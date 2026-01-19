using OtabapaLeague.Application.UI.Windows.GameEditor;
using OtabapaLeague.Data.Player;
using OtabapaLeague.Scripts.Data;
using OtabapaLeague.Scripts.Domain.Systems.Games;
using OtabapaLeague.Scripts.Domain.Systems.Players;
using Unity.VisualScripting;

namespace OtabapaLeague.Application.UI.Screens.Games
{
    public class GameWindowPresenter : ViewPresenter<GamesWindowView>
    {
        private readonly IGamesManager _gamesManager;
        private readonly IPlayerManager _playerManager;
        private readonly IMainUIController _mainUIController;
        
        public GameWindowPresenter(IGamesManager gamesManager, IPlayerManager playerManager, IMainUIController mainUIController)
        {
            _gamesManager = gamesManager;
            _playerManager = playerManager;
            _mainUIController = mainUIController;
        }
        
        public override void OnViewReady()
        {
            LoadGames();
            View.OnAddGameButtonClickedEvent += OnAddGameButtonClicked;
            _gamesManager.OnGameRegisteredEvent += OnGameRegistered;
        }

        public override void OnViewDisabled()
        {
            View.OnAddGameButtonClickedEvent -= OnAddGameButtonClicked;
            _gamesManager.OnGameRegisteredEvent -= OnGameRegistered;
        }

        private void LoadGames()
        {
            View.ClearGames();
            var games = _gamesManager.AllGames;
            foreach (var game in games)
            {
                AddGame(game);
            }
        }

        private void AddGame(GameModel gameModel)
        {
            View.AddGame(
                GetPlayerData(gameModel.FirstPlayer, gameModel.FirstPlayerScore),
                GetPlayerData(gameModel.SecondPlayer, gameModel.SecondPlayerScore),
                gameModel.Result);
        }
        
        private void OnAddGameButtonClicked()
        {
            _mainUIController.OpenGameEditor(OnEditorSubmitGame);
        }

        private void OnEditorSubmitGame(GameEditorSubmitArgs args)
        {
            var firstPlayer = _playerManager.GetPlayer(args.FirstPlayerId);
            var secondPlayer = _playerManager.GetPlayer(args.SecondPlayerId);
            _gamesManager.RegisterGame(firstPlayer, secondPlayer, args.FirstPlayerScore, args.SecondPlayerScore);
        }

        private void OnGameRegistered(GameModel gameModel)
        {
            LoadGames();
        }
        
        private GameResultsPlayerData GetPlayerData(int playerId, int gameScore)
        {
            if (_playerManager.TryGetPlayer(playerId, out var player))
            {
                return new GameResultsPlayerData(player.Name, player.Tag, gameScore);
            }
            
            return new GameResultsPlayerData("Unknown", "???", gameScore);
        }
    }
}