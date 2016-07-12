using System;

namespace TorrentTracker.Data.StringApproximation.Methods
{
    public class LevenshteinsDistance : IStringApproximation
    {
        public double GetSimilarity(string toCompare, string toCompareWith)
        {
            var editDistance = CalculateLevenshteinsDistanc(toCompare, toCompare.Length - 1, toCompareWith, toCompareWith.Length - 1);

            return 1 - (editDistance / Math.Max(toCompare.Length, toCompareWith.Length));
        }

        private double CalculateLevenshteinsDistanc(string toCompare, int stringToCompareLength, string toCompareWith, int stringToCompareWithLength)
        {
            if (stringToCompareLength == 0) return stringToCompareWithLength;

            if (stringToCompareWithLength == 0) return stringToCompareLength;

            var distance = 0;
            if (toCompare[stringToCompareLength - 1] != toCompareWith[stringToCompareWithLength - 1])
                distance = 1;

            return Math.Min(
                Math.Min(
                    CalculateLevenshteinsDistanc(toCompare, stringToCompareLength - 1, toCompareWith, stringToCompareWithLength) + 1,
                    CalculateLevenshteinsDistanc(toCompare, stringToCompareLength, toCompareWith, stringToCompareWithLength - 1) + 1),
                CalculateLevenshteinsDistanc(toCompare, stringToCompareLength - 1, toCompareWith, stringToCompareWithLength - 1) + distance);
        }
    }
}
