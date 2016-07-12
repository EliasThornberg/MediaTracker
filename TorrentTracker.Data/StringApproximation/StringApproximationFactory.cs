using TorrentTracker.Data.StringApproximation.Methods;

namespace TorrentTracker.Data.StringApproximation
{
    public class StringApproximationFactory : IStringApproximationFactory
    {
        public IStringApproximation Create(ApproximationMethod method)
        {
            switch(method)
            {
                case ApproximationMethod.HammingDistance:
                    return new HammingDistance();
                case ApproximationMethod.LevenshteinsDistance:
                    return new LevenshteinsDistance();
                case ApproximationMethod.OverlapCoefficient:
                    return new OverlapCoefficient();
                case ApproximationMethod.JaccardDistance:
                    return new JaccardDistance();
                default:
                    return null;
            }
        }
    }
}
