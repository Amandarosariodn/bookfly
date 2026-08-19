using bookfly.Domain.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace bookfly.Infra.Repositories
{
    public class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        protected readonly ISession Session;

        public RepositoryBase(ISession session)
        {
            Session = session;
        }

        public virtual async Task EditarAsync(TEntity entity, CancellationToken cancellationToken)
            => await Session.UpdateAsync(entity, cancellationToken);

        public virtual async Task InserirAsync(TEntity entity, CancellationToken cancellationToken) 
            => await Session.SaveAsync(entity, cancellationToken);

        public virtual async Task<IList<TEntity>> ListarAsync(CancellationToken cancellationToken) 
            => await Session.Query<TEntity>().ToListAsync(cancellationToken);

        public virtual async Task<TEntity> RecuperarAsync(TId id, CancellationToken cancellationToken) 
            => await Session.GetAsync<TEntity>(id, cancellationToken);
    }
}