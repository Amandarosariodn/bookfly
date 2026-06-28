using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using bookfly.Domain.Posts.Entities;
using bookfly.Domain.Posts.Repositories.Filters;
using bookfly.Domain.Posts.Repositories.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace bookfly.Infra.Posts.Repositories
{
    public class PostRepository(ISession session) : IPostRepository
    {
        public async Task EditarAsync(Post post, CancellationToken cancellationToken)
        {
            if (post == null)
                throw new ArgumentNullException(nameof(post));

            await session.UpdateAsync(post, cancellationToken);
        }

        public IQueryable<Post> Filtrar()
        {
            return session.Query<Post>();
        }

        public async Task InserirAsync(Post post, CancellationToken cancellationToken)
        {
            if (post == null)
                throw new ArgumentNullException(nameof(post));

            await session.SaveAsync(post, cancellationToken);
        }

        public async Task<List<Post>> ListarAsync(PostFiltro filtro, CancellationToken cancellationToken)
        {
            var query = session.Query<Post>();

            if (filtro.ComunidadeId.HasValue)
                query = query.Where(p => p.ComunidadeId == filtro.ComunidadeId.Value);

            if (filtro.AutorId.HasValue)
                query = query.Where(p => p.AutorId == filtro.AutorId.Value);

            if (filtro.LivroId.HasValue)
                query = query.Where(p => p.LivroId == filtro.LivroId.Value);

            if (filtro.Fixado.HasValue)
                query = query.Where(p => p.Fixado == filtro.Fixado.Value);

            if (!string.IsNullOrWhiteSpace(filtro.Texto))
                query = query.Where(p => p.Titulo.Contains(filtro.Texto) || p.Conteudo.Contains(filtro.Texto));

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Post?> RecuperarPorIdAsync(long postId, CancellationToken cancellationToken)
        {
            return await session.GetAsync<Post>(postId, cancellationToken);
        }
    }
}