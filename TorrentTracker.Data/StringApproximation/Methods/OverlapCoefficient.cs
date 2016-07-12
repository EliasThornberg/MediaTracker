using System;
using System.Linq;
using TorrentTracker.Data.StringApproximation.Common;

namespace TorrentTracker.Data.StringApproximation.Methods
{
    public class OverlapCoefficient : IStringApproximation
    {
        public double GetSimilarity(string toCompare, string toCompareWith)
        {
            var toCompareWithSet = NgramTokenizer.CreateNgram(toCompareWith, 2);
            var toCompareSet = NgramTokenizer.CreateNgram(toCompare, 2);

            double intersectionSize = toCompareSet.Intersect(toCompareWithSet).Count();
            double minSetSize = Math.Min(toCompareSet.Count(), toCompareWithSet.Count());

            return intersectionSize / minSetSize;
        }
    }
}
