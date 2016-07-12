using System.Threading.Tasks;

namespace TorrentTracker.Core.Interface.CQRS
{
    public interface IAsyncQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}
