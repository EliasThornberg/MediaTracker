using System;
using System.Linq;
using TorrentTracker.Data.StringApproximation.Common;

namespace TorrentTracker.Data.StringApproximation.Methods
{
    public class JaccardDistance : IStringApproximation
    {
        public double GetSimilarity(string toCompare, string toCompareWith)
        {
            var toCompareWithSet = NgramTokenizer.CreateNgram(toCompareWith, 2);
            var toCompareSet = NgramTokenizer.CreateNgram(toCompare, 2);

            double intersectionSize = toCompareSet.Intersect(toCompareWithSet).Count();
            double unionSize = toCompareSet.Union(toCompareWithSet).Count();

            return intersectionSize / unionSize;
        }
    }
}
