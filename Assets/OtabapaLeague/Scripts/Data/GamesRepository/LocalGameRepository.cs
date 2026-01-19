using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using OtabapaLeague.Data.Systems;

namespace OtabapaLeague.Scripts.Data.GamesRepository
{
    public class LocalGameRepository : IGamesRepository
    {
        public List<GameModel> AllGames => _gamesById.Values.ToList();

        private const string GamesDataKey = "GamesData";
        private readonly IDataSaver _dataSaver;
        
        private Dictionary<int, GameModel> _gamesById;
        
        public LocalGameRepository(IDataSaver dataSaver)
        {
            _dataSaver = dataSaver; 
            
            _gamesById = new Dictionary<int, GameModel>();
        }
        
        public async UniTask Load()
        {
            await LoadGameList();
        }

        public async UniTask<GameModel> SaveGame(int firstPlayerId, int secondPlayerId, int firstPlayerScore, int secondPlayerScore,
            GameResult result, int ratingShift)
        {
            int newGameId = GetNextId();
            var player = new GameModel(newGameId, firstPlayerId, secondPlayerId, firstPlayerScore, secondPlayerScore,
                result, ratingShift);
            
            _gamesById.Add(newGameId, player);
            
            await SaveGameList();
            return player;
        }

        public UniTask DeleteGame(GameModel game)
        {
            if(_gamesById.Remove(game.Id))
            {
                return SaveGameList();
            }
            return UniTask.CompletedTask;
        }

        private async UniTask LoadGameList()
        {
            var data = await _dataSaver.LoadData<List<GameModel>>(GamesDataKey);
            if (data != null && data.Count > 0)
                _gamesById = data.ToDictionary(item => item.Id, item => item);
            else
                _gamesById = new Dictionary<int, GameModel>();
        }
        
        private async UniTask SaveGameList()
        {
            var dataToSave = _gamesById.Values.ToList();
            await _dataSaver.SaveData(GamesDataKey, dataToSave);
        }
        
        private int GetNextId()
        {
            if (_gamesById.Count == 0)
                return 1;
            
            return _gamesById.Keys.Max() + 1;
        }
    }
}