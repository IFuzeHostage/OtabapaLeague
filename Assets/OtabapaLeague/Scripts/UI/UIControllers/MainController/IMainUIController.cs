using System;
using Cysharp.Threading.Tasks;
using OtabapaLeague.Application.UI.Windows;

namespace OtabapaLeague.Application.UI
{
    public interface IMainUIController
    {
        UniTask OpenMainMenu();
        UniTask CloseMainMenu();

        UniTask OpenPlayersWindow();
        UniTask ClosePlayersWindow();

        UniTask OpenAddPlayerEditor(Action<PlayerEditSubmitEventArgs> addCallback);
        UniTask OpenPlayerEditor(string playerTag, Action<PlayerEditSubmitEventArgs> editCallback);
        UniTask ClosePlayerEditor();
    }
}