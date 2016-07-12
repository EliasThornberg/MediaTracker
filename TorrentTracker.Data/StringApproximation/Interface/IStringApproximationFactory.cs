namespace TorrentTracker.Data.StringApproximation
{
    public interface IStringApproximationFactory
    {
        IStringApproximation Create(ApproximationMethod method);
    }
}
