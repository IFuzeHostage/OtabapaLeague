namespace OtabapaLeague.Application.UI.Windows
{
    public class PlayerEditSubmitEventArgs
    {
        public readonly string Name;
        public readonly string Tag;
        public readonly int Score;
        
        public PlayerEditSubmitEventArgs(string name, string tag, int score)
        {
            Name = name;
            Tag = tag;
            Score = score;
        }
    }
}