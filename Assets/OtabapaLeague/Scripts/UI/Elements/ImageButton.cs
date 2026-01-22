using UnityEngine;

namespace OtabapaLeague.Application.UI.Elements
{
    public class ImageButton : UIButton
    {
        [SerializeField]
        private UnityEngine.UI.Image _image;
        
        public void SetImage(Sprite sprite)
        {
            _image.sprite = sprite;
        }
    }
}