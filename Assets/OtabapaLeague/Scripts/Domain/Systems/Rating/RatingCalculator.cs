using OtabapaLeague.Scripts.Data;

namespace OtabapaLeague.Scripts.Domain.Systems.Rating
{
    public class RatingCalculator : IRatingCalculator
    {
        public int CalculateRatingShift(int firstRating, int secondRating, GameResult result)
        {
            return 20;
        }

        public int GetStartingRating()
        {
            return 1500;
        }
    }
}