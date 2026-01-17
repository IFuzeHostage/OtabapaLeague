using System;
using System.Collections.Generic;
using Zenject.SpaceFighter;
using Player = OtabapaLeague.Data.Player.Player;

namespace OtabapaLeague.Scripts.Domain.Systems.Players
{
    public interface IPlayerManager
    {
        event Action<Player> OnPlayerAdded;
        event Action<Player> OnPlayerUpdated;
        event Action<Player> OnPlayerRemoved;
        
        IEnumerable<Player> AllPlayers { get; }
        
        void AddNewPlayer(string name, string tag);
        void UpdatePlayer(Player player);
        bool TryGetPlayer(int id, out Player player);
        void RemovePlayer(int id);
    }
}