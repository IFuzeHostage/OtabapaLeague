using System.Collections.Generic;
using System.Linq;
using OtabapaLeague.Data.Player;
using OtabapaLeague.Scripts.Domain.Systems.Players;

namespace OtabapaLeague.Application.UI.Screens.RatingWindow
{
    public class RatingScreenPresenter : ViewPresenter<RatingScreenView>
    {
        private readonly IPlayerManager _playerManager;
        
        public RatingScreenPresenter(IPlayerManager playerManager)
        {
            _playerManager = playerManager;
        }
        
        public override void OnViewReady()
        {
            LoadPlayerList();
        }

        public override void OnViewDisabled()
        {
            
        }

        private void LoadPlayerList()
        {
            var orderedPlayers = GetPlayersPlaced();
            View.ClearPlayers();
            foreach (var (place, player) in orderedPlayers)
            {
                AddPlayerToView(place, player);
            }
        }
        
        private Dictionary<int, PlayerModel> GetPlayersPlaced()
        {
            var ordered = _playerManager.AllPlayers.OrderByDescending(player => player.Rating);
            int place = 0;
            return ordered.ToDictionary(player => place++, player => player);
        }

        private void AddPlayerToView(int place, PlayerModel player)
        {
            View.AddPlayer(player.Name, player.Tag, place + 1, player.Rating);
        }
    }
}