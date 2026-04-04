    using NHibernate;
    using bookfly.Application.Shared.UnitOfWork;

    namespace bookfly.Infra.UnitOfWork
    {
        public class NHibernateUnitOfWork : IUnitOfWork
        {
            private readonly ISession _session;
            private ITransaction? _transaction;

            public NHibernateUnitOfWork(ISession session)
            {
                _session = session;
            }

            public Task BeginAsync(CancellationToken cancellationToken)
            {
                _transaction = _session.BeginTransaction();
                return Task.CompletedTask;
            }

            public async Task CommitAsync(CancellationToken cancellationToken)
            {
                if (_transaction == null)
                    throw new InvalidOperationException("Nenhuma transação iniciada.");

                await _transaction.CommitAsync(cancellationToken);
            }

            public async Task RollbackAsync(CancellationToken cancellationToken)
            {
                if (_transaction != null)
                    await _transaction.RollbackAsync(cancellationToken);
            }

            public void Dispose()
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }
    }