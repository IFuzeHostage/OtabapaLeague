using OtabapaLeague.Application.UI;
using UnityEngine;
using Zenject;

namespace OtabapaLeague.Application.ScenePresenters
{
    public class MainMenuPresenter : MonoBehaviour
    {
        private IMainUIController _mainUIController;

        [Inject]
        public void Construct(IMainUIController mainUIController)
        {
            _mainUIController = mainUIController;
        }

        private void Start()
        {
            OpenMainMenuScreen();
        }

        private void OpenMainMenuScreen()
        {
            _mainUIController.OpenMainMenu();
        }
    }
}