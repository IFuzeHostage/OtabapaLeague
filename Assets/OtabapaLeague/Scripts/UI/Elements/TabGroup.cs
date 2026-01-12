using System;
using System.Collections.Generic;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Elements
{
    public class TabGroup : MonoBehaviour
    {
        public event Action<int> OnTabChanged;
        
        public int ButtonCount => _buttons.Count;
        
        [SerializeField]
        private List<TextButton> _buttons;

        public void SetButtonAtIndex(int buttonIndex, string buttonText)
        {
            if (buttonIndex < 0 || buttonIndex >= _buttons.Count)
                throw new ArgumentOutOfRangeException(nameof(buttonIndex), "Button index is out of range.");
            
            _buttons[buttonIndex].SetText(buttonText);
        }
        
        private void Awake()
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                int index = i;
                _buttons[i].OnClick += () => OnTabSelected(index);
            }
        }
        
        private void OnTabSelected(int index)
        {
            OnTabChanged?.Invoke(index);
        }
    }
}