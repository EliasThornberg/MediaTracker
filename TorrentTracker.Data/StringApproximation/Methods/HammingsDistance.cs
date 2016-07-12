using System.Linq;

namespace TorrentTracker.Data.StringApproximation.Methods
{
    public class HammingDistance : IStringApproximation
    {
        public double GetSimilarity(string toCompare, string toCompareWith)
        {
            if (toCompare.Length != toCompareWith.Length)
                return int.MaxValue;

            return toCompare.Zip(toCompareWith, (s, i) => s == i ? 0 : 1).Sum();
        }
    }
}
