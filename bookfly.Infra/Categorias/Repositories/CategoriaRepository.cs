

using bookfly.Domain.Categorias.Entities;
using bookfly.Domain.Categorias.Repositories;
using NHibernate;


namespace bookfly.Infra.Categorias.Repositories
{
    public class CategoriaRepository : ICategoriasRepository
    {

        private readonly ISession _session;

        public CategoriaRepository(ISession session)
        {
            _session = session;
        }

        public Task AtualizarAsync(Categoria categoria, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        // public IQueryable<Categoria> Filtrar()
        // {
        
        // }

        public Task InserirAsync(Categoria categoria, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria?> RecuperarPorId(int categoriaId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}