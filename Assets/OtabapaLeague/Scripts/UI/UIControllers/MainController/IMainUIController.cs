using System;
using Cysharp.Threading.Tasks;
using OtabapaLeague.Application.UI.Windows;
using OtabapaLeague.Application.UI.Windows.GameEditor;

namespace OtabapaLeague.Application.UI
{
    public interface IMainUIController
    {
        UniTask OpenMainMenu();
        UniTask CloseMainMenu();

        UniTask OpenPlayersWindow();
        UniTask ClosePlayersWindow();

        UniTask OpenAddPlayerEditor(Action<PlayerEditSubmitEventArgs> addCallback);
        UniTask OpenPlayerEditor(int playerId, Action<PlayerEditSubmitEventArgs> editCallback);
        UniTask ClosePlayerEditor();

        UniTask OpenGameWindow();
        UniTask CloseGameWindow();
        
        UniTask OpenGameEditor(Action<GameEditorSubmitArgs> onSubmit);
        UniTask CloseGameEditor();
    }
}