using UnityEngine;

namespace OtabapaLeague.Application.UI.Screens.MainMenuScreen
{
    public class MainMenuViewPresenter : ViewPresenter<MainMenuView>
    {
        private IMainUIController _mainUIController;
        
        public MainMenuViewPresenter(IMainUIController mainUIController)
        {
            _mainUIController = mainUIController;
        }
        
        public override void OnViewReady()
        {
            for(int i = 0; i < 3; i++)
            {
                View.SetTabName(i, ((MainMenuTabs)i).ToString());
            }
            
            View.OnTabSelected += OnViewTabChanged;
        }

        public override void OnViewDisabled()
        {
            View.OnTabSelected -= OnViewTabChanged;
        }
        
        private void OnViewTabChanged(int index)
        {
            var tab = (MainMenuTabs)index;
            switch (tab)
            {
                case MainMenuTabs.Games:
                    Debug.Log("Open Games Tab");
                    break;
                case MainMenuTabs.Players:
                    _mainUIController.OpenPlayersWindow();
                    break;
                case MainMenuTabs.Rating:
                    Debug.Log("Open Rating Tab");
                    break;
            }
        }
    }
}