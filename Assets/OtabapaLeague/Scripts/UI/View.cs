using Cysharp.Threading.Tasks;
using OtabapaLeague.Application.UI.Elements;
using UnityEngine;

namespace OtabapaLeague.Application.UI
{
    public abstract class View : UIElement
    {
        private CanvasGroup _canvasGroup;

        public virtual UniTask Open()
        {
            _canvasGroup.alpha = 1;
            return UniTask.CompletedTask;
        }
        
        public virtual UniTask Close()
        {
            _canvasGroup.alpha = 0;
            return UniTask.CompletedTask;
        }

        protected override void InitComponents()
        {
            base.InitComponents();
            _canvasGroup = GetComponent<CanvasGroup>();
        }
    }
}