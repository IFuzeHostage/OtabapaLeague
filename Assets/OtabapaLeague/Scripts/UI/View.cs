using UnityEngine;

namespace OtabapaLeague.Scripts.UI
{
    public abstract class View : MonoBehaviour
    {
        public RectTransform Rect => _rectTransform;
        
        private RectTransform _rectTransform;
        
        protected void Init()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
    }
}