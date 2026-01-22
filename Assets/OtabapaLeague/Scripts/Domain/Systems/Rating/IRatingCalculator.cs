using System.Collections.Generic;
using OtabapaLeague.Scripts.Data;

namespace OtabapaLeague.Scripts.Domain.Systems.Rating
{
    public interface IRatingCalculator
    {
        int CalculateRatingShift(int firstRating, int secondRating, GameResult result);
        int GetStartingRating();
    }
}