using Cysharp.Threading.Tasks;
using OtabapaLeague.Scripts.Domain.UIController;
using UnityEngine;

namespace OtabapaLeague.Scripts.UI.Views.Screens.MainMenuScreen
{
    public class MainMenuEndpoint : IMainMenuEndpoint
    {
        private const string _viewPath = "p_ui_main";

        private IUIHolder _uiHolder;
        private MainMenuView _view;
        
        public MainMenuEndpoint(IUIHolder uiHolder)
        {
            _uiHolder = uiHolder;
        }
        
        public async UniTask Open()
        {
            LoadView();
            await _view.Open();
        }

        public async UniTask Close()
        {
            await _view.Close();
            _uiHolder.RemoveView(_viewPath);
        }

        private void LoadView()
        {
            var viewPrefab = Resources.Load<MainMenuView>(_viewPath);
            _view = GameObject.Instantiate(viewPrefab);
            _uiHolder.AddView(_viewPath, _view);
        }
    }
}