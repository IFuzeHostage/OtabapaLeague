using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using OtabapaLeague.Data.Player;
using OtabapaLeague.Scripts.Data;
using OtabapaLeague.Scripts.Data.GamesRepository;
using OtabapaLeague.Scripts.Domain.Systems.Players;
using OtabapaLeague.Scripts.Domain.Systems.Rating;

namespace OtabapaLeague.Scripts.Domain.Systems.Games
{
    public class GameManager : IGamesManager
    {
        public event Action<GameModel> OnGameRegisteredEvent;
        public List<GameModel> AllGames => _gamesRepository.AllGames;

        private IGamesRepository _gamesRepository;
        private IRatingCalculator _ratingCalculator;
        private IPlayerManager _playerManager;
        
        public GameManager(IGamesRepository gamesRepository, IPlayerManager playerManager, IRatingCalculator ratingCalculator)
        {
            _gamesRepository = gamesRepository;
            _playerManager = playerManager;
            _ratingCalculator = ratingCalculator;
        }
        
        public void RegisterGame(PlayerModel firstPlayerModel, PlayerModel secondPlayerModel, 
            int firstPlayerScore, int secondPlayerScore)
        {
            GameResult result;
            if (firstPlayerScore > secondPlayerScore)
                result = GameResult.FirstPlayerWin;
            else if (firstPlayerScore < secondPlayerScore)
                result = GameResult.SecondPlayerWin;
            else
                result = GameResult.Draw;

            int ratingShift = _ratingCalculator.CalculateRatingShift(firstPlayerModel.Rating, secondPlayerModel.Rating, result);

            ShiftPlayerRating(firstPlayerModel, secondPlayerModel, result, ratingShift).Forget();
            RequestGameRegistration(firstPlayerModel.Id, firstPlayerScore, secondPlayerModel.Id, secondPlayerScore, 
                result, ratingShift).Forget();
        }

        public void RemoveGame(int gameId)
        {
            var gameModel = _gamesRepository.AllGames.Find(game => game.Id == gameId);
            if (gameModel != null)
            {
                _gamesRepository.DeleteGame(gameModel);
            }
        }

        private async UniTask RequestGameRegistration(int firstId, int firstScore, int secondId, int secondScore, GameResult result,
            int ratingShift)
        {
            var gameModel = await _gamesRepository.SaveGame(firstId, secondId, 
                firstScore, secondScore, result, ratingShift);
            
            OnGameRegisteredEvent?.Invoke(gameModel);
        }

        private UniTask ShiftPlayerRating(PlayerModel firstPlayer, PlayerModel secondPlayer, 
            GameResult result, int ratingShift)
        {
            var firstPlayerRating = firstPlayer.Rating + ratingShift * (result == GameResult.FirstPlayerWin ? 1 : -1);
            var secondPlayerRating = secondPlayer.Rating + ratingShift * (result == GameResult.SecondPlayerWin ? 1 : -1);
            
            firstPlayer.UpdateRating(firstPlayerRating);
            secondPlayer.UpdateRating(secondPlayerRating);
            
            _playerManager.UpdatePlayer(firstPlayer);
            _playerManager.UpdatePlayer(secondPlayer);
            
            return UniTask.CompletedTask;
        }
    }
}