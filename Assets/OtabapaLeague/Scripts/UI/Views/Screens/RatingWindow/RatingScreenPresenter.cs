using System.Collections.Generic;
using System.Linq;
using OtabapaLeague.Data.Player;
using OtabapaLeague.Scripts.Data.AvatarsRepository;
using OtabapaLeague.Scripts.Domain.Systems.Players;

namespace OtabapaLeague.Application.UI.Screens.RatingWindow
{
    public class RatingScreenPresenter : ViewPresenter<RatingScreenView>
    {
        private readonly IPlayerManager _playerManager;
        private readonly IPlayerAvatarsRepository _avatarRepository;
        
        public RatingScreenPresenter(IPlayerManager playerManager, IPlayerAvatarsRepository avatarsRepository)
        {
            _playerManager = playerManager;
            _avatarRepository = avatarsRepository;
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
            var avatar = _avatarRepository.GetAvatar(player.Id);
            View.AddPlayer(player.Name, player.Tag, place + 1, player.Rating, avatar);
        }
    }
}