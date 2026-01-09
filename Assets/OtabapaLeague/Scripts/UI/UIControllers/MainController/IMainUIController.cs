using Cysharp.Threading.Tasks;

namespace OtabapaLeague.Scripts.UI.UIControllers.MainController
{
    public interface IMainUIController
    {
        UniTask OpenMainMenu();
        UniTask CloseMainMenu();
    }
}