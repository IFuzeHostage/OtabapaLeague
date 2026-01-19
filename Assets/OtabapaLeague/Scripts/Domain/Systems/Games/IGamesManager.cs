using System.Collections.Generic;
using OtabapaLeague.Data.Player;
using OtabapaLeague.Scripts.Data;

namespace OtabapaLeague.Scripts.Domain.Systems.Games
{
    public interface IGamesManager
    {
        List<GameModel> AllGames { get; }
        
        void RegisterGame(PlayerModel firstPlayerModel, PlayerModel secondPlayerModel, 
            int firstPlayerScore, int secondPlayerScore);
        void RemoveGame(int gameId);
    }
}