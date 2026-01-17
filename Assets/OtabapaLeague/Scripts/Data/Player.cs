namespace OtabapaLeague.Data.Player
{
    public class Player
    {
        public int Id => _id;
        public string Name => _name;
        public string Tag => _tag;
        public int Score => _score;

        private int _id;
        private string _name;
        private string _tag;
        private int _score;
        
        public Player(int id, string name, string tag, int score)
        {
            _id = id;
            _tag = tag;
            _name = name;
            _score = score;
        }
        
        public void UpdateName(string newName)
        {
            _name = newName;
        }
        
        public void UpdateTag(string newTag)
        {
            _tag = newTag;
        }
        
        public void UpdateScore(int newScore)
        {
            _score = newScore;
        }
    }
}