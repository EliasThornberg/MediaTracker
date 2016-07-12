using System.Threading.Tasks;

namespace TorrentTracker.Core.Interface.CQRS
{
    public interface IAsyncCommandHandler<in TCommand, TResult> where TCommand : ICommand<TResult>
    {
        Task<TResult> Handle(TCommand command);
    }
}
