using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace bookfly.Domain.Interfaces
{
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        Task<TEntity> RecuperarAsync(TId id, CancellationToken cancellationToken);
        Task<IList<TEntity>> ListarAsync(CancellationToken cancellationToken);
        Task InserirAsync(TEntity entity, CancellationToken cancellationToken);
        Task EditarAsync(TEntity entity, CancellationToken cancellationToken);
    }
}