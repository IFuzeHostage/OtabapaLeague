using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace OtabapaLeague.Data.Player
{
    public interface IPlayersRepository
    {
        List<Player> AllPlayers { get; }
        
        UniTask Load();
        UniTask<Player> AddPlayer(string name, string tag, int score);
        UniTask UpdatePlayer(Player player);
        UniTask RemovePlayer(int playerId);
        Player GetPlayerById(int id);
    }
}