using OtabapaLeague.Scripts.Data;
using UnityEngine;

namespace OtabapaLeague.Scripts.Domain.Systems.Rating
{
    public class EloRatingCalculator : IRatingCalculator
    {
        private const int StartingRating = 1500;
        private const int KFactor = 32;
        private const int RatingDifferenceDivisor = 400;
        
        public int CalculateRatingShift(int firstRating, int secondRating, GameResult result)
        {
            var expectedScoreFirst = CalculateExpectedScore(firstRating, secondRating);
            var expectedScoreSecond = 1 - expectedScoreFirst;
            var shift = result == GameResult.FirstPlayerWin
                ? KFactor * (1 - expectedScoreFirst)
                : KFactor * (1 - expectedScoreSecond);
            
            return (int)shift;
        }

        public int GetStartingRating()
        {
            return 1500;
        }
        
        private float CalculateExpectedScore(int playerRating, int opponentRating)
        {
            return 1 / (1 + Mathf.Pow(10, (opponentRating - playerRating) / (float)RatingDifferenceDivisor));
        }
    }
}