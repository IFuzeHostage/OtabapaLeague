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

        public override UniTask Open()
        {
            _presenter.OnViewReady();
            return base.Open();
        }
        
        public override UniTask Close()
        {
            _presenter.OnViewDisabled();
            return base.Close();
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