using TMPro;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Elements
{
    public class PlayerViewSimple : UIElement
    {
        [SerializeField]
        private UIText _nameText;
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
    }
}