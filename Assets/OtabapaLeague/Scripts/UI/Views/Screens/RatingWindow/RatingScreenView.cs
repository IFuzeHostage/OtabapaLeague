using System.Collections.Generic;
using OtabapaLeague.Application.UI.Elements;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Screens.RatingWindow
{
    public class RatingScreenView : View
    {
        [SerializeField]
        private RectTransform __playerParent;
        [SerializeField]
        private PlacedPlayerView _playerViewPrefab;
        
        private Dictionary<int, PlacedPlayerView> _playersByPlace = new Dictionary<int, PlacedPlayerView>();
        
        public PlacedPlayerView AddPlayer(string name, string tag, int place, int rating, Sprite avatar)
        {
            var playerView = Instantiate(_playerViewPrefab, __playerParent);
            playerView.SetPlayer(name, tag);
            playerView.SetPlace(place);
            playerView.SetScore(rating);
            playerView.SetAvatar(avatar);
            _playersByPlace.Add(place, playerView);
            return playerView;
        }
        
        public void ClearPlayers()
        {
            foreach (var player in _playersByPlace)
            {
                Destroy(player.Value.gameObject);
            }
            _playersByPlace.Clear();
        }
    }
}