using System;
using System.Collections.Generic;
using OtabapaLeague.Data.Player;

namespace OtabapaLeague.Scripts.Domain.Systems.Players
{
    public class PlayerManager : IPlayerManager
    {
        public event Action<Player> OnPlayerAdded;
        public event Action<Player> OnPlayerRemoved;
        
        public IEnumerable<Player> AllPlayers => _playersRepository.AllPlayers;
        
        private IPlayersRepository _playersRepository;
        
        public PlayerManager(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }
        
        public void AddNewPlayer(string name, string tag)
        {
            var player = new Player(name, tag, 0);
            _playersRepository.AddPlayer(player);
            OnPlayerAdded?.Invoke(player);
        }

        public bool TryGetPlayer(string tag, out Player player)
        {
            player = _playersRepository.GetPlayerByTag(tag);
            
            return player != null;
        }
    }
}