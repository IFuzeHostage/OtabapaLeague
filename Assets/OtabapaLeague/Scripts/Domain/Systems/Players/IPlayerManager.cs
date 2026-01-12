using System.Collections.Generic;
using Zenject.SpaceFighter;
using Player = OtabapaLeague.Data.Player.Player;

namespace OtabapaLeague.Scripts.Domain.Systems.Players
{
    public interface IPlayerManager
    {
        IEnumerable<Player> AllPlayers { get; }
        
        void AddNewPlayer(string name, string tag);
    }
}