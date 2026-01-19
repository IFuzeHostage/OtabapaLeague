namespace OtabapaLeague.Scripts.Data
{
    public class GameResultsPlayerData
    {
        public readonly string Name;
        public readonly string Tag;
        public readonly int Score;
        
        public GameResultsPlayerData(string name, string tag, int score)
        {
            Name = name;
            Tag = tag;
            Score = score;
        }
    }
}