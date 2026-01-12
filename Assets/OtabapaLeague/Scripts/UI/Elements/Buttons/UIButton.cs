using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OtabapaLeague.Application.UI.Elements
{
    public class UIButton : MonoBehaviour
    {
        public event Action OnClick; 
        
        [SerializeField]
        private Button _button;
        
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