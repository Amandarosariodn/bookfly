
using bookfly.Domain.Avaliacoes.Commands;
using bookfly.Domain.Avaliacoes.Entities;
using bookfly.Domain.Avaliacoes.Repositories;
using bookfly.Domain.Avaliacoes.Repositories.Filters;
using bookfly.Domain.Avaliacoes.Services.Interfaces;

namespace bookfly.Domain.Avaliacoes.Services
{
    public class AvaliacaoService(IAvaliacaoRepository avaliacaoRepository) : IAvaliacaoService
    {
        public async Task<Avaliacao> InserirAsync(InserirAvaliacaoCommand comando, CancellationToken cancellationToken)
        {
            Avaliacao avaliacao = Instanciar(comando);

            await avaliacaoRepository.InserirAsync(avaliacao, cancellationToken);
            return avaliacao;
        }

        public async Task<Avaliacao> EditarAsync(EditarAvaliacaoCommand comando, int id, CancellationToken cancellationToken)
        {
            Avaliacao avaliacao = await ObterPorIdAsync(id, cancellationToken);

            if (avaliacao == null)
            {
                throw new Exception("Avaliação não encontrada.");
            }

            avaliacao.SetLivroId(comando.LivroId);
            avaliacao.SetNota(comando.Nota);
            avaliacao.SetReview(comando.Review);

            await avaliacaoRepository.EditarAsync(avaliacao, cancellationToken);
            return avaliacao;
        }

        public async Task ExcluirAsync(Avaliacao avaliacao, CancellationToken cancellationToken)
        {
            await avaliacaoRepository.ExcluirAsync(avaliacao, cancellationToken);
        }

        public async Task<IEnumerable<Avaliacao>> ListarAvaliacoesAsync(AvaliacaoFiltro filtro, CancellationToken cancellationToken)
        {
            var avaliacoes = await avaliacaoRepository.ListarAvaliacoesAsync(filtro, cancellationToken);

            if (avaliacoes == null || !avaliacoes.Any())
                return new List<Avaliacao>();

            return avaliacoes ?? new List<Avaliacao>();
        }

        public async Task<Avaliacao?> ObterPorIdAsync(int id, CancellationToken cancellationToken)
        {
            Avaliacao? avaliacao = await avaliacaoRepository.ObterPorIdAsync(id, cancellationToken);

            if (avaliacao == null)
                throw new Exception("Avaliação não encontrada");

            return avaliacao;
        }

        private Avaliacao Instanciar(InserirAvaliacaoCommand comando)
        {
            return new Avaliacao(comando.UsuarioId, comando.LivroId, comando.Nota, comando.Review, comando.ContemSpoiler, DateTime.Now);
        }
    }
}