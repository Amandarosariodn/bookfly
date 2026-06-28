
using bookfly.Domain.Avaliacoes.Entities;
using bookfly.Domain.Avaliacoes.Repositories;
using bookfly.Domain.Avaliacoes.Repositories.Filters;
using NHibernate;
using NHibernate.Linq;

namespace bookfly.Infra.Avaliacoes.Repositories
{
    public class AvaliacaoRepository(ISession session) : IAvaliacaoRepository
    {
        private readonly ISession _session = session;



        public async Task EditarAsync(Avaliacao avaliacao, CancellationToken cancellationToken)
        {
            if (avaliacao == null)
                throw new ArgumentNullException(nameof(avaliacao));
            await _session.UpdateAsync(avaliacao, cancellationToken);
        }

        public async Task ExcluirAsync(Avaliacao avaliacao, CancellationToken cancellationToken)
        {
            if (avaliacao == null)
                throw new ArgumentNullException(nameof(avaliacao));
            await _session.DeleteAsync(avaliacao, cancellationToken);
        }

        public async Task InserirAsync(Avaliacao avaliacao, CancellationToken cancellationToken)
        {
            if (avaliacao == null)
                throw new ArgumentNullException(nameof(avaliacao));
            await _session.SaveAsync(avaliacao, cancellationToken);
        }

        public async Task<List<Avaliacao>> ListarAvaliacoesAsync(AvaliacaoFiltro filtro, CancellationToken cancellationToken)
        {
            var query = session.Query<Avaliacao>();

            // if (filtro.UsuarioId.HasValue)
            //     query = query.Where(c => c.UsuarioId == filtro.UsuarioId.Value);

            // if (filtro.LivroId.HasValue)
            //     query = query.Where(c => c.LivroId == filtro.LivroId.Value);

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Avaliacao?> ObterPorIdAsync(int id, CancellationToken cancellationToken)
        {
            return await session.GetAsync<Avaliacao>(id, cancellationToken);
        }
    }
}