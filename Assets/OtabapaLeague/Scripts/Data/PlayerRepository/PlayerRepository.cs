using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using OtabapaLeague.Data.Systems;
using UnityEngine;

namespace OtabapaLeague.Data.Player
{
    public class PlayerRepository : IPlayersRepository
    {
        public List<Player> AllPlayers => _playersById.Values.ToList();
     
        private const string PLAYER_DATA_KEY = "PlayersData";
        private readonly IDataSaver _dataSaver;
        
        private Dictionary<int, Player> _playersById;
        
        public PlayerRepository(IDataSaver dataSaver)
        {
            _dataSaver = dataSaver;
            _playersById = new Dictionary<int, Player>();
        }

        public async UniTask Load()
        {
            await LoadPlayerList();
        }

        public async UniTask<Player> AddPlayer(string name, string tag, int score)
        {
            if(_playersById.Values.Any(player => player.Tag == tag))
            {
                Debug.LogError("Player with such tag already exists: " + tag);
                return _playersById.Values.First(player => player.Tag == tag);
            }

            int newPlayerId = GetNextId();
            var player = new Player(newPlayerId, name, tag, score);
            _playersById.Add(newPlayerId, player);
            
            await SavePlayerList();
            return player;
        }

        public async UniTask UpdatePlayer(Player player)
        {
            await SavePlayerList();
        }

        public async UniTask RemovePlayer(int playerId)
        {
            if(_playersById.Remove(playerId))
            {
                await SavePlayerList();
            }

            Debug.LogError("No player with such tag to remove: " + playerId);
        }

        public Player GetPlayerById(int id)
        {
            if(_playersById.TryGetValue(id, out var player))
            {
                return player;
            }

            return null;
        }

        private async UniTask LoadPlayerList()
        {
            var playerList = await _dataSaver.LoadData<List<Player>>(PLAYER_DATA_KEY);
            if (playerList != null)
            {
                _playersById = playerList.ToDictionary(player => player.Id, player => player);
            }
            else
            {
                _playersById = new Dictionary<int, Player>();
            }
        }
        
        private async UniTask SavePlayerList()
        {
            var playerList = _playersById.Values.ToList();
            await _dataSaver.SaveData(PLAYER_DATA_KEY, playerList);
        }

        private int GetNextId()
        {
            if(_playersById.Count == 0)
            {
                return 0;
            }
            
            return _playersById.Values.Max(player => player.Id) + 1;   
        }
    }
}