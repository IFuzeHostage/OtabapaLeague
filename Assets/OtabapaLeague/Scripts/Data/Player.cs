namespace OtabapaLeague.Data.Player
{
    public class Player
    {
        public string Name => _name;
        public string Tag => _tag;
        public int Score => _score;
        
        private string _name;
        private string _tag;
        private int _score;
        
        public Player(string name, string tag, int score)
        {
            _tag = tag;
            _name = name;
            _score = score;
        }
        
        public void UpdateScore(int newScore)
        {
            _score = newScore;
        }
        
        public void UpdateName(string newName)
        {
            _name = newName;
        }
    }
}