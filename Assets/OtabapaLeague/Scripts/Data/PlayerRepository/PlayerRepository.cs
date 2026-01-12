using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using OtabapaLeague.Data.Systems;

namespace OtabapaLeague.Data.Player
{
    public class PlayerRepository : IPlayersRepository
    {
        public List<Player> AllPlayers => _playersByTag.Values.ToList();
     
        private const string PLAYER_DATA_KEY = "PlayersData";
        private readonly IDataSaver _dataSaver;
        
        private Dictionary<string, Player> _playersByTag;
        
        public PlayerRepository(IDataSaver dataSaver)
        {
            _dataSaver = dataSaver;
            _playersByTag = new Dictionary<string, Player>();
        }

        public async UniTask Load()
        {
            await LoadPlayerList();
        }

        public async UniTask<Player> AddPlayer(string name, string tag)
        {
            var newPlayer = new Player(name, tag, 0);
            _playersByTag.Add(tag, newPlayer);
            
            await SavePlayerList();
            return newPlayer;
        }

        public async UniTask<Player> GetPlayerByTag(string tag)
        {
            if(_playersByTag.TryGetValue(tag, out var player))
            {
                return player;
            }
            
            throw new KeyNotFoundException($"Player with tag {tag} not found.");
        }

        private async UniTask LoadPlayerList()
        {
            var playerList = await _dataSaver.LoadData<List<Player>>(PLAYER_DATA_KEY);
            if (playerList != null)
            {
                _playersByTag = playerList.ToDictionary(player => player.Tag, player => player);
            }
        }
        
        private async UniTask SavePlayerList()
        {
            var playerList = _playersByTag.Values.ToList();
            await _dataSaver.SaveData(PLAYER_DATA_KEY, playerList);
        }
    }
}