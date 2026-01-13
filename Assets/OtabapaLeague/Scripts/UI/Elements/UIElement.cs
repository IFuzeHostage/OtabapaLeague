using UnityEngine;

namespace OtabapaLeague.Application.UI.Elements
{
    public class UIElement : MonoBehaviour
    {
        public RectTransform Rect => _rectTransform;
        
        private RectTransform _rectTransform;

        protected virtual void InitComponents()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
        
        protected virtual void Awake()
        {
            InitComponents();
        }
    }
}