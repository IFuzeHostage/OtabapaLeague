using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace OtabapaLeague.Scripts.Data.GamesRepository
{
    public interface IGamesRepository
    {
        public List<GameModel> AllGames { get; }
        
        UniTask Load();
        UniTask<GameModel> SaveGame(int firstPlayerId, int secondPlayerId, int firstPlayerScore, int secondPlayerScore, 
            GameResult result, int ratingShift);
        UniTask DeleteGame(GameModel game);
    }
}