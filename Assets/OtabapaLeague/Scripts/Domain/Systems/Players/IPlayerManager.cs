using System;
using System.Collections.Generic;
using OtabapaLeague.Data.Player;
using Zenject.SpaceFighter;

namespace OtabapaLeague.Scripts.Domain.Systems.Players
{
    public interface IPlayerManager
    {
        event Action<PlayerModel> OnPlayerAdded;
        event Action<PlayerModel> OnPlayerUpdated;
        event Action<PlayerModel> OnPlayerRemoved;
        
        IEnumerable<PlayerModel> AllPlayers { get; }
        
        void AddNewPlayer(string name, string tag);
        void UpdatePlayer(PlayerModel playerModel);
        PlayerModel GetPlayer(int id);
        bool TryGetPlayer(int id, out PlayerModel playerModel);
        void RemovePlayer(int id);
    }
}