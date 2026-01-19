namespace OtabapaLeague.Data.Player
{
    public class PlayerModel
    {
        public int Id => _id;
        public string Name => _name;
        public string Tag => _tag;
        public int Rating => _rating;

        private int _id;
        private string _name;
        private string _tag;
        private int _rating;
        
        public PlayerModel(int id, string name, string tag, int rating)
        {
            _id = id;
            _tag = tag;
            _name = name;
            _rating = rating;
        }
        
        public void UpdateName(string newName)
        {
            _name = newName;
        }
        
        public void UpdateTag(string newTag)
        {
            _tag = newTag;
        }
        
        public void UpdateRating(int newScore)
        {
            _rating = newScore;
        }
    }
}