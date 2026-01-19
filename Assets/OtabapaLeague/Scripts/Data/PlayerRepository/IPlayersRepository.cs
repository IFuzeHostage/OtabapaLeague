using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace OtabapaLeague.Data.Player
{
    public interface IPlayersRepository
    {
        List<PlayerModel> AllPlayers { get; }
        
        UniTask Load();
        UniTask<PlayerModel> AddPlayer(string name, string tag, int score);
        UniTask UpdatePlayer(PlayerModel playerModel);
        UniTask RemovePlayer(int playerId);
        PlayerModel GetPlayerById(int id);
    }
}