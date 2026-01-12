using Cysharp.Threading.Tasks;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Screens.PlayersWindow
{
    public class PlayersWindowEndpoint : IPlayersWindowEndpoint
    {
        private const string _viewPath = "p_ui_players";

        private IUIHolder _uiHolder;
        private PlayersWindowView _view;
        
        public PlayersWindowEndpoint(IUIHolder uiHolder)
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
            var viewPrefab = Resources.Load<PlayersWindowView>(_viewPath);
            _view = GameObject.Instantiate(viewPrefab);
            _uiHolder.AddView(_viewPath, _view);
        }
    }
}