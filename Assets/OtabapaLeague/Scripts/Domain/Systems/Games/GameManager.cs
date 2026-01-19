using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using OtabapaLeague.Data.Player;
using OtabapaLeague.Scripts.Data;
using OtabapaLeague.Scripts.Data.GamesRepository;

namespace OtabapaLeague.Scripts.Domain.Systems.Games
{
    public class GameManager : IGamesManager
    {
        public List<GameModel> AllGames => _gamesRepository.AllGames;

        private IGamesRepository _gamesRepository;
        
        public GameManager(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
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

            int ratingShift = 20; 

            _gamesRepository.SaveGame(firstPlayerModel.Id, secondPlayerModel.Id, 
                firstPlayerScore, secondPlayerScore, result, ratingShift);
        }

        public void RemoveGame(int gameId)
        {
            var gameModel = _gamesRepository.AllGames.Find(game => game.Id == gameId);
            if (gameModel != null)
            {
                _gamesRepository.DeleteGame(gameModel);
            }
        }
    }
}