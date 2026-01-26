using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using OtabapaLeague.Data.Player;
using OtabapaLeague.Scripts.Data.AvatarsRepository;
using OtabapaLeague.Scripts.Domain.Systems.Rating;
using UnityEngine;

namespace OtabapaLeague.Scripts.Domain.Systems.Players
{
    public class PlayerManager : IPlayerManager
    {
        public event Action<PlayerModel> OnPlayerAdded;
        public event Action<PlayerModel> OnPlayerUpdated;
        public event Action<PlayerModel> OnPlayerRemoved;
        
        public IEnumerable<PlayerModel> AllPlayers => _playersRepository.AllPlayers;
        private IPlayersRepository _playersRepository;
        private IRatingCalculator _ratingCalculator;
        private IPlayerAvatarsRepository _playerAvatarsRepository;
        
        public PlayerManager(IPlayersRepository playersRepository, IRatingCalculator ratingCalculator,
            IPlayerAvatarsRepository playerAvatarsRepository)
        {
            _playersRepository = playersRepository;
            _ratingCalculator = ratingCalculator;
            _playerAvatarsRepository = playerAvatarsRepository;
        }
        
        public async void AddNewPlayer(string name, string tag, Sprite avatar)
        {
            var newPlayer = await _playersRepository.AddPlayer(name, tag, _ratingCalculator.GetStartingRating());
            OnPlayerAdded?.Invoke(newPlayer);
            _playerAvatarsRepository.SaveAvatar(newPlayer.Id, avatar);
        }

        public void UpdatePlayer(PlayerModel playerModel)
        {
            _playersRepository.UpdatePlayer(playerModel);
            OnPlayerUpdated?.Invoke(playerModel);
        }

        public PlayerModel GetPlayer(int id)
        {
            return _playersRepository.GetPlayerById(id);
        }

        public void RemovePlayer(int targetId)
        {
            var existingPlayer = _playersRepository.GetPlayerById(targetId);
            var exists = existingPlayer != null;
            
            if(exists)
            {
                _playersRepository.RemovePlayer(targetId);
                OnPlayerRemoved?.Invoke(existingPlayer);
            }
        }
        
        public bool TryGetPlayer(int targetId, out PlayerModel playerModel)
        {
            playerModel = _playersRepository.GetPlayerById(targetId);
            
            return playerModel != null;
        }

        private string FixTag(string tag)
        {
            if (tag.StartsWith("@"))
                return tag;
            
            return "@" + tag;
        }
    }
}