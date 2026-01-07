using System;
using OtabapaLeague.Scripts.UI.Elements;
using UnityEngine;

namespace OtabapaLeague.Scripts.UI.Views.Screens.MainMenuScreen
{
    public class MainMenuView : View
    {
        public event Action<int> OnTabSelected;
        
        [SerializeField] 
        private TabGroup _tabs;

        private MainMenuPresenter _presenter;
        
        public void Init(MainMenuPresenter presenter)
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
            Init();
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