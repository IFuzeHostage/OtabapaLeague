using UnityEngine;

namespace OtabapaLeague.Scripts.Domain.UIController
{
    public class UIParent : MonoBehaviour
    {
        public RectTransform ScreenParent => _screenParent;
        public RectTransform WindowParent => _windowParent;
        
        [SerializeField]
        private RectTransform _screenParent;
        [SerializeField]
        private RectTransform _windowParent;
    }
}