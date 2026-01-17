using System;
using System.Collections.Generic;
using OtabapaLeague.Data.Player;

namespace OtabapaLeague.Scripts.Domain.Systems.Players
{
    public class PlayerManager : IPlayerManager
    {
        public event Action<Player> OnPlayerAdded;
        public event Action<Player> OnPlayerUpdated;
        public event Action<Player> OnPlayerRemoved;
        
        public IEnumerable<Player> AllPlayers => _playersRepository.AllPlayers;
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

        public void UpdatePlayer(Player player)
        {
            _playersRepository.UpdatePlayer(player);
            OnPlayerUpdated?.Invoke(player);
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
        
        public bool TryGetPlayer(int targetId, out Player player)
        {
            player = _playersRepository.GetPlayerById(targetId);
            
            return player != null;
        }
    }
}