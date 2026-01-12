using OtabapaLeague.Application.UI.Elements;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Screens.PlayersWindow
{
    public class PlayersWindowView : View
    {
        [SerializeField]
        private RectTransform _playersParent;
        [SerializeField]
        private PlayerView _playerViewPrefab;
        [SerializeField]
        private UIButton _addPlayerBuutton;
    }
}