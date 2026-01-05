using Cysharp.Threading.Tasks;
using OtabapaLeague.Scripts.UI;
using UnityEngine;

namespace OtabapaLeague.Scripts.Domain.UIController
{
    public interface IUIHolder
    {
        UniTask Init(UIParent uiParent);
        void AddView(View view, string viewName);
        void RemoveView(string view);
        View GetView(string viewName);
    }
}