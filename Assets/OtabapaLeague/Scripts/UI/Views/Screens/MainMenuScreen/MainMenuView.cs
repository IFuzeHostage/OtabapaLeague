using System;
using Cysharp.Threading.Tasks;
using OtabapaLeague.Application.UI.Elements;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Screens.MainMenuScreen
{
    public class MainMenuView : View
    {
        public event Action<int> OnTabSelected;
        
        [SerializeField] 
        private TabGroup _tabs;

        public void SetTabName(int index, string tabName)
        {
            _tabs.SetButtonAtIndex(index, tabName);
        }

        protected override void InitComponents()
        {
            _tabs.OnTabChanged += OnTabChanged;
            base.InitComponents();
        }

        private void OnDestroy()
        {
            _tabs.OnTabChanged -= OnTabChanged;
        }

        private void OnTabChanged(int index)
        {
            OnTabSelected?.Invoke(index);
        }
    }
}