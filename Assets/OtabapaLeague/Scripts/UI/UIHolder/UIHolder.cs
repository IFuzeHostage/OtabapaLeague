using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using OtabapaLeague.Scripts.Domain.UIController;
using UnityEngine;

namespace OtabapaLeague.Application.UI
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

        public void AddView(string viewName, View view)
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

        public bool TryGetView(string viewName, out View view)
        {
            return _views.TryGetValue(viewName, out view);
        }
    }
}