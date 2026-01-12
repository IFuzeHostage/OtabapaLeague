using System;
using OtabapaLeague.Application.UI.Elements;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Screens.MainMenuScreen
{
    public class MainMenuView : View
    {
        public event Action<int> OnTabSelected;
        
        [SerializeField] 
        private TabGroup _tabs;

        private MainMenuViewPresenter _presenter;
        
        public void Init(MainMenuViewPresenter presenter)
        {
            _presenter = presenter;
            _presenter.SetView(this);
        }

        public void SetTabName(int index, string tabName)
        {
            _tabs.SetButtonAtIndex(index, tabName);
        }
        
        private void Awake()
        {
            _tabs.OnTabChanged += OnTabChanged;
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