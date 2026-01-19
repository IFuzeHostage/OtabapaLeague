using OtabapaLeague.Data.Player;

namespace OtabapaLeague.Scripts.Data
{
    public class GameModel
    {
        public readonly int Id;
        public readonly int FirstPlayer;
        public readonly int FirstPlayerScore;
        public readonly int SecondPlayer;
        public readonly int SecondPlayerScore;
        public readonly GameResult Result;
        public readonly int RatingShift;
        
        public GameModel(int id, int firstPlayer, int firstPlayerScore, int secondPlayer, int secondPlayerScore, 
            GameResult result, int ratingShift)
        {
            Id = id;
            FirstPlayer = firstPlayer;
            FirstPlayerScore = firstPlayerScore;
            SecondPlayer = secondPlayer;
            SecondPlayerScore = secondPlayerScore;
            Result = result;
            RatingShift = ratingShift;
        }
    }
}