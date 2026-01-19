using System;
using System.Collections.Generic;
using OtabapaLeague.Data.Player;

namespace OtabapaLeague.Scripts.Domain.Systems.Players
{
    public class PlayerManager : IPlayerManager
    {
        public event Action<PlayerModel> OnPlayerAdded;
        public event Action<PlayerModel> OnPlayerUpdated;
        public event Action<PlayerModel> OnPlayerRemoved;
        
        public IEnumerable<PlayerModel> AllPlayers => _playersRepository.AllPlayers;
        private IPlayersRepository _playersRepository;
        
        public PlayerManager(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }
        
        public async void AddNewPlayer(string name, string tag)
        {
            var newPlayer = await _playersRepository.AddPlayer(name, tag, 0);
            OnPlayerAdded?.Invoke(newPlayer);
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
    }
}