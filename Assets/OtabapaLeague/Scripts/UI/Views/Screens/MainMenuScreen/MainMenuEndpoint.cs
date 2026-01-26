using Cysharp.Threading.Tasks;
using OtabapaLeague.Scripts.Domain.UIController;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Screens.MainMenuScreen
{
    public class MainMenuEndpoint : LoaderEndpoint<MainMenuView>, IMainMenuEndpoint
    {
        protected override string ViewPath => "p_ui_main";
        
        private IMainUIController _mainUIController;
        
        protected MainMenuViewPresenter _presenter;
        
        public MainMenuEndpoint(IUIHolder uiHolder) : base(uiHolder)
        {
        }

        //TODO this is ass
        public void SetController(IMainUIController mainUIController)
        {
            _mainUIController = mainUIController;
        }

        protected override void InitView()
        {
            _presenter = new MainMenuViewPresenter(_mainUIController);
            _presenter.SetView(View);
        }

        protected override void DisposeView()
        {
            _presenter.DetachView();
        }
    }
}