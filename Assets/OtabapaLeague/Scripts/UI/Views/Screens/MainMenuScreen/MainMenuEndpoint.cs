using Cysharp.Threading.Tasks;
using OtabapaLeague.Scripts.Domain.UIController;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Screens.MainMenuScreen
{
    public class MainMenuEndpoint : IMainMenuEndpoint
    {
        private const string _viewPath = "p_ui_main";

        private readonly IUIHolder _uiHolder;
        private IMainUIController _mainUIController;
        
        private MainMenuView _view;

        public MainMenuEndpoint(IUIHolder uiHolder)
        {
            _uiHolder = uiHolder;
        }

        //TODO this is ass
        public void SetController(IMainUIController mainUIController)
        {
            _mainUIController = mainUIController;
        }

        public async UniTask Open()
        {
            LoadView();
            var presenter = new MainMenuViewPresenter(_mainUIController);
            _view.Init(presenter);
            await _view.Open();
        }

        public async UniTask Close()
        {
            await _view.Close();
            _uiHolder.RemoveView(_viewPath);
        }

        private void LoadView()
        {
            if (_uiHolder.TryGetView(_viewPath, out var view))
            {
                _view = (MainMenuView)view;
                return;
            }
            var viewPrefab = Resources.Load<MainMenuView>(_viewPath);
            _view = GameObject.Instantiate(viewPrefab);
            _uiHolder.AddView(_viewPath, _view);
        }
    }
}