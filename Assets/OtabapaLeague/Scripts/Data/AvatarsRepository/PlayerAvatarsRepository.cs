using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using OtabapaLeague.Data.Systems;
using OtabapaLeague.Scripts.Domain.Systems.Files;
using UnityEngine;

namespace OtabapaLeague.Scripts.Data.AvatarsRepository
{
    public class PlayerAvatarsRepository : IPlayerAvatarsRepository
    {
        private const string AvatarPathsKey = "avatar_paths";
        private const string AvatarPathFormat = "player_avatar_{0}";
        
        private readonly IFileSystem _fileSystem;
        private readonly IDataSaver _dataSaver;

        private HashSet<int> _playerIdsWithSavedAvatars = new HashSet<int>();
        private Dictionary<int, Sprite> _avatarsByPlayerId = new Dictionary<int, Sprite>();
        
        public PlayerAvatarsRepository(IFileSystem fileSystem, IDataSaver dataSaver)
        {
            _fileSystem = fileSystem;
            _dataSaver = dataSaver;
        }

        public async UniTask Load()
        {
            _playerIdsWithSavedAvatars = await _dataSaver.LoadData<HashSet<int>>(AvatarPathsKey);
            
            if(_playerIdsWithSavedAvatars == null || _playerIdsWithSavedAvatars.Count == 0)
            {
                _playerIdsWithSavedAvatars = new HashSet<int>();
                return;
            }
            
            foreach (var playerId in _playerIdsWithSavedAvatars)
            {
                _avatarsByPlayerId[playerId] = LoadAvatar(playerId);
            }
        }

        public Sprite SelectAvatar()
        {
            return _fileSystem.SelectImage();
        }
        
        public void SaveAvatar(int playerId, Sprite avatar)
        {
            if (avatar != null)
            {
                string key = GetAvatarPath(playerId);
                _fileSystem.SaveImage(avatar, key);
                _playerIdsWithSavedAvatars.Add(playerId);
                _avatarsByPlayerId[playerId] = _fileSystem.LoadSprite(key);
                _dataSaver.SaveData(AvatarPathsKey, _playerIdsWithSavedAvatars);
            }
        }

        public Sprite GetAvatar(int playerId)
        {
            if (_avatarsByPlayerId.TryGetValue(playerId, out var srite))
            {
                return srite;
            }
            return null;
        }
        
        private Sprite LoadAvatar(int playerId)
        {
            return _fileSystem.LoadSprite(GetAvatarPath(playerId));
        }

        private string GetAvatarPath(int playerId)
        {
            return string.Format(AvatarPathFormat, playerId);
        }
    }
}