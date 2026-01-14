using UnityEngine;

namespace OtabapaLeague.Application.UI.Elements
{
    public class PlayerView : UIElement
    {
        [SerializeField]
        private UIText _nameText;
        [SerializeField]
        private UIText _scoreText;
        [SerializeField] 
        private UIText _tagText;

        public void SetName(string name)
        {
            _nameText.Text = name;
        }

        public void SetTag(string tag)
        {
            _tagText.Text = tag;
        }
        
        public void SetScore(int score)
        {
            _scoreText.Text = score.ToString();
        }
    }
}