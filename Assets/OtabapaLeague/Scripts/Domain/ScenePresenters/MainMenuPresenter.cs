using System.Collections;
using System.Collections.Generic;
using OtabapaLeague.Scripts.UI.UIControllers.MainController;
using UnityEngine;
using Zenject;

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
