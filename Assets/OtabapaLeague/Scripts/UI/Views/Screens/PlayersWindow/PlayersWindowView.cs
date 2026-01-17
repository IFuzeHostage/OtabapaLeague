using System;
using UnityEngine;
using System.Collections.Generic;
using OtabapaLeague.Application.UI.Elements;

namespace OtabapaLeague.Application.UI.Screens.PlayersWindow
{
    public class PlayersWindowView : View
    {
        public event Action OnAddPlayerClicked;
        
        [SerializeField]
        private RectTransform _playersParent;
        [SerializeField]
        private PlayerView _playerViewPrefab;
        [SerializeField]
        private UIButton _addPlayerBuutton;
        
        private List<PlayerView> _playerViews = new List<PlayerView>();
        
        public PlayerView AddPlayer(string name, string tag, int score)
        {
            var playerView = Instantiate(_playerViewPrefab, _playersParent);
            playerView.SetName(name);
            playerView.SetTag(tag);
            playerView.SetScore(score);
            
            _playerViews.Add(playerView);
            return playerView;
        }

        public void ClearPlayers()
        {
            foreach (Transform child in _playersParent)
            {
                Destroy(child.gameObject);
            }
        }
        
        protected override void InitComponents()
        {
            base.InitComponents();
            _addPlayerBuutton.OnClick += OnAddPlayerButtonClicked;
        }

        private void OnAddPlayerButtonClicked()
        {
            OnAddPlayerClicked?.Invoke();
        }
    }
}