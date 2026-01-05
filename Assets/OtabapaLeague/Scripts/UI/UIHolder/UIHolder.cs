using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using OtabapaLeague.Scripts.UI;
using UnityEngine;

namespace OtabapaLeague.Scripts.Domain.UIController
{
    public class UIHolder : IUIHolder
    {
        private UIParent _uiParent;
        
        private Dictionary<string, View > _views = new Dictionary<string, View>();
        
        public UniTask Init(UIParent uiParent)
        {
            _uiParent = uiParent;
            return UniTask.CompletedTask;
        }

        public void AddView(View view, string viewName)
        {
            _views.Add(viewName, view);
            view.transform.SetParent(_uiParent.ScreenParent, false);
        }

        public void RemoveView(string viewName)
        {
            if (_views.TryGetValue(viewName, out var view))
            {
                _views.Remove(viewName);
                GameObject.Destroy(view);
            }
        }

        public View GetView(string viewName)
        {
            return _views[viewName];
        }
    }
}