using Cysharp.Threading.Tasks;
using UnityEngine;

namespace OtabapaLeague.Scripts.UI
{
    public abstract class View : MonoBehaviour
    {
        public RectTransform Rect => _rectTransform;
        
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        
        protected void Init()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

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
    }
}