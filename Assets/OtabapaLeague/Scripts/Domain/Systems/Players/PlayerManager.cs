using System.Collections.Generic;
using OtabapaLeague.Data.Player;

namespace OtabapaLeague.Scripts.Domain.Systems.Players
{
    public class PlayerManager : IPlayerManager
    {
        public IEnumerable<Player> AllPlayers => _playersRepository.AllPlayers;
        
        private IPlayersRepository _playersRepository;
        
        public PlayerManager(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }
        
        public void AddNewPlayer(string name, string tag)
        {
            throw new System.NotImplementedException();
        }
    }
}