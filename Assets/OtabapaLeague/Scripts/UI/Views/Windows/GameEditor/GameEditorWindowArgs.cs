using System;

namespace OtabapaLeague.Application.UI.Windows.GameEditor
{
    public class GameEditorWindowArgs
    {
        public Action<GameEditorSubmitArgs> OnSubmit;

        public GameEditorWindowArgs(Action<GameEditorSubmitArgs> onSubmit)
        {
            OnSubmit = onSubmit;
        }
    }
}