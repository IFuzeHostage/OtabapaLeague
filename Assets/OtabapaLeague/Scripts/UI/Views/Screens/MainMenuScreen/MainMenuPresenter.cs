using UnityEngine;

namespace OtabapaLeague.Scripts.UI.Views.Screens.MainMenuScreen
{
    public class MainMenuPresenter : ViewPresenter<MainMenuView>
    {
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
                    Debug.Log("Open Players Tab");
                    break;
                case MainMenuTabs.Rating:
                    Debug.Log("Open Rating Tab");
                    break;
            }
        }
    }
}