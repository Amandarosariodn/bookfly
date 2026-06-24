
using bookfly.Domain.Avaliacoes.Entities;
using bookfly.Domain.Avaliacoes.Repositories;
using bookfly.Domain.Avaliacoes.Repositories.Filters;
using NHibernate;

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

        public async   Task InserirAsync(Avaliacao avaliacao, CancellationToken cancellationToken)
        {
            if (avaliacao == null)
                throw new ArgumentNullException(nameof(avaliacao));
            await _session.SaveAsync(avaliacao, cancellationToken);
        }

        public async Task<IEnumerable<Avaliacao>> ListarAvaliacoesAsync(AvaliacaoFiltro filtro, CancellationToken cancellationToken)
        {
            if (filtro == null)
                throw new ArgumentNullException(nameof(filtro));
            throw new NotImplementedException();
        }

        public async Task<Avaliacao?> ObterPorIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            throw new NotImplementedException();
        }

        public async Task FiltrarAsync(AvaliacaoFiltro filtro, CancellationToken cancellationToken)
        {
            if (filtro == null)
                throw new ArgumentNullException(nameof(filtro));
            throw new NotImplementedException();
        }

        public async Task BuscarNomeLivroAsync(Avaliacao avaliacao, CancellationToken cancellationToken)
        {
            
        }
    }
}