using System;
using OtabapaLeague.Application.UI.Elements;
using UnityEngine;

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
        
        public void AddPlayer(string name, string tag, int score)
        {
            var playerView = Instantiate(_playerViewPrefab, _playersParent);
            playerView.SetName(name);
            playerView.SetTag(tag);
            playerView.SetScore(score);
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