namespace OtabapaLeague.Application.UI.Windows.GameEditor
{
    public class GameEditorSubmitArgs
    {
        public readonly int FirstPlayerId;
        public readonly int SecondPlayerId;
        public readonly int FirstPlayerScore;
        public readonly int SecondPlayerScore;
        
        public GameEditorSubmitArgs(int firstPlayerId, int secondPlayerId, int firstPlayerScore, int secondPlayerScore)
        {
            this.FirstPlayerId = firstPlayerId;
            this.SecondPlayerId = secondPlayerId;
            this.FirstPlayerScore = firstPlayerScore;
            this.SecondPlayerScore = secondPlayerScore;
        }
    }
}