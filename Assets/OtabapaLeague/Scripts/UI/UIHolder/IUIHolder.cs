using Cysharp.Threading.Tasks;
using OtabapaLeague.Scripts.Domain.UIController;

namespace OtabapaLeague.Application.UI
{
    public interface IUIHolder
    {
        UniTask Init(UIParent uiParent);
        void AddView(string viewName, View view);
        void RemoveView(string view);
        View GetView(string viewName);
        bool TryGetView(string viewName, out View view);
    }
}