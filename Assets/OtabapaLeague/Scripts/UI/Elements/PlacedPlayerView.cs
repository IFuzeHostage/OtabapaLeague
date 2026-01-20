using UnityEngine;

namespace OtabapaLeague.Application.UI.Elements
{
    public class PlacedPlayerView : UIElement
    {
        [SerializeField]
        private UIText _placeText;
        [SerializeField]
        private PlayerViewSimple _playerSimpleView;
        [SerializeField]
        private UIText _scoreText;
        
        public void SetPlace(int place)
        {
            _placeText.Text = place.ToString();
        }
        
        public void SetPlayer(string name, string tag)
        {
            _playerSimpleView.SetName(name);
            _playerSimpleView.SetTag(tag);
        }
        
        public void SetScore(int score)
        {
            _scoreText.Text = score.ToString();
        }
    }
}