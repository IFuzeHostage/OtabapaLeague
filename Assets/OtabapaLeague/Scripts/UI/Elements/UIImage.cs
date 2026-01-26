using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace OtabapaLeague.Application.UI.Elements
{
    public class UIImage : UIElement
    {
        [SerializeField]
        private Image _image;

        public void SetImage(Sprite sprite)
        {
            _image.sprite = sprite;
            _image.enabled = sprite != null;
        }
    }
}