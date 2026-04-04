
namespace bookfly.Application.Shared.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginAsync(CancellationToken cancellationToken);
        Task CommitAsync(CancellationToken cancellationToken);
        Task RollbackAsync(CancellationToken cancellationToken);
    }
}