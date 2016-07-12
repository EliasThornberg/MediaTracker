namespace TorrentTracker.Data.StringApproximation
{
    public interface IStringApproximation
    {
        double GetSimilarity(string toCompare, string toCompareWith);
    }
}
