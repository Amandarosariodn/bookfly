using bookfly.Domain.Livros.Entities;
using bookfly.Domain.Livros.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace bookfly.Infra.Livros.Repositories
{
    public class LivroRepository(ISession session) : ILivrosRepository
    {
        private readonly ISession _session = session;

        public async Task EditarAsync(Livro livro, CancellationToken cancellationToken)
        {
            if (livro == null)
                throw new ArgumentNullException(nameof(livro));

            await _session.UpdateAsync(livro, cancellationToken);
        }

        public async Task InserirAsync(Livro livro, CancellationToken cancellationToken)
        {
            if (livro == null)
                throw new ArgumentNullException(nameof(livro));
                

            await _session.SaveAsync(livro, cancellationToken);
        }

        public async Task<List<Livro>> ListarAsync(string titulo, string autor, CancellationToken cancellationToken)
        {
            var query = _session.Query<Livro>();

            if (!string.IsNullOrEmpty(titulo))
                query = query.Where(l => l.Titulo.Contains(titulo));
            if (!string.IsNullOrEmpty(autor))
                query = query.Where(l => l.Autor.Contains(autor));

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Livro> RecuperarPorIdAsync(int livroId, CancellationToken cancellationToken)
        {
            return await _session.GetAsync<Livro>(livroId, cancellationToken);
        }
        
    }
}