using System;
using Cysharp.Threading.Tasks;
using OtabapaLeague.Application.UI.Elements;
using UnityEngine;

namespace OtabapaLeague.Application.UI
{
    public abstract class View : UIElement
    {
        public event Action OnOpened;
        public event Action OnClosed;
        
        private CanvasGroup _canvasGroup;

        public virtual UniTask Open()
        {
            _canvasGroup.alpha = 1;
            OnOpened?.Invoke();
            return UniTask.CompletedTask;
        }
        
        public virtual UniTask Close()
        {
            _canvasGroup.alpha = 0;
            OnClosed?.Invoke();
            return UniTask.CompletedTask;
        }

        protected override void InitComponents()
        {
            base.InitComponents();
            _canvasGroup = GetComponent<CanvasGroup>();
        }
    }
}