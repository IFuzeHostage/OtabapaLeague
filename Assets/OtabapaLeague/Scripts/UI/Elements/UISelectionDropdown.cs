using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Elements
{
    public class UISelectionDropdown : UIElement
    {
        public event Action<int> OnIndexSelected;
        
        public int CurrentIndex => _dropdown.value;
        
        [SerializeField]
        private TMP_Dropdown _dropdown;
        
        public void SetList(List<string> options)
        {
            _dropdown.ClearOptions();
            _dropdown.AddOptions(options);
        }
        
        public void SetIndex(int index)
        {
            _dropdown.value = index;
        }
        
        protected override void InitComponents()
        {
            base.InitComponents();
            _dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        }
        
        private void OnDropdownValueChanged(int index)
        {
            OnIndexSelected?.Invoke(index);
        }
    }
}