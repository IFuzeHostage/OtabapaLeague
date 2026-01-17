using UnityEngine;

namespace OtabapaLeague.Application.UI.Elements
{
    public class GameViewPlayer : UIElement
    {
        [SerializeField]
        private PlayerViewSimple _playerView;
        [SerializeField]
        private UIText _scoreText;
        [SerializeField]
        private UIText _resultText;
        
        public void SetPlayer(string name, string tag)
        {
            _playerView.SetName(name);
            _playerView.SetTag(tag);
        }
        
        public void SetPlayerScoreText(int score)
        {
            _scoreText.Text = score.ToString();
        }
        
        public void SetResultText(string result)
        {
            _resultText.Text = result;
        }
    }
}