using UnityEngine;

namespace OtabapaLeague.Application.UI.Elements
{
    public class UITextInput : UIElement
    {
        [SerializeField]
        private TMPro.TMP_InputField _inputField;

        public string Text
        {
            get => _inputField.text;
            set => _inputField.text = value;
        }
    }
}