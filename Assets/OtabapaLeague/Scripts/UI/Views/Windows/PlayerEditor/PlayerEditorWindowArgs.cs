using System;

namespace OtabapaLeague.Application.UI.Windows
{
    public class PlayerEditorWindowArgs
    {
        public readonly int Id;
        public readonly Action<PlayerEditSubmitEventArgs> EditCallback;
        
        public PlayerEditorWindowArgs(int id, Action<PlayerEditSubmitEventArgs> editCallback)
        {
            Id = id;
            EditCallback = editCallback;
        }
    }
}