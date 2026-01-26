using UnityEngine;

namespace OtabapaLeague.Application.UI.Windows
{
    public class PlayerEditSubmitEventArgs
    {
        public readonly string Name;
        public readonly string Tag;
        public readonly Sprite Avatar;
        
        public PlayerEditSubmitEventArgs(string name, string tag, Sprite avatar)
        {
            Name = name;
            Tag = tag;
            Avatar = avatar;
        }
    }
}