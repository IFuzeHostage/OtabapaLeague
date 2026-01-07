using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OtabapaLeague.Scripts.UI.Elements
{
    public class UIButton : MonoBehaviour
    {
        public event Action OnClick; 
        
        [SerializeField]
        private TextMeshProUGUI _buttonText;
        [SerializeField]
        private Button _button;
        
        public virtual void SetText(string text)
        {
            _buttonText.text = text;
        }
        
        public virtual void SetInteractable(bool interactable)
        {
            _button.interactable = interactable;
        }
        
        private void Awake()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            OnClick?.Invoke();
        }
    }
}