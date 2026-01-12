using TMPro;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Elements
{
    public class TextButton : UIButton
    {
        [SerializeField]
        private TextMeshProUGUI _buttonText;
        
        public virtual void SetText(string text)
        {
            _buttonText.text = text;
        }
    }
}