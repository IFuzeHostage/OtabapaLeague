using System;

namespace OtabapaLeague.Application.UI.Windows
{
    public class PlayerEditorWindowArgs
    {
        public readonly string Tag;
        public readonly Action<PlayerEditSubmitEventArgs> EditCallback;
        
        public PlayerEditorWindowArgs(string tag, Action<PlayerEditSubmitEventArgs> editCallback)
        {
            Tag = tag;
            EditCallback = editCallback;
        }
    }
}