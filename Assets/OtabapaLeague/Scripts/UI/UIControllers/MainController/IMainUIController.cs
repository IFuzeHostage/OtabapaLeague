using Cysharp.Threading.Tasks;

namespace OtabapaLeague.Application.UI
{
    public interface IMainUIController
    {
        UniTask OpenMainMenu();
        UniTask CloseMainMenu();

        UniTask OpenPlayersWindow();
        UniTask ClosePlayersWindow();
    }
}