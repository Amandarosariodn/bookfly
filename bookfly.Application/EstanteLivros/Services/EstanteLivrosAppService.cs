
using bookfly.Application.EstanteLivros.DataTransfer.Requests;
using bookfly.Application.EstanteLivros.DataTransfer.Responses;
using bookfly.Application.EstanteLivros.Services.Interfaces;
using bookfly.Application.Shared.UnitOfWork;
using bookfly.Domain.EstanteLivros.Commands;
using bookfly.Domain.EstanteLivros.Entities;
using bookfly.Domain.EstanteLivros.Repositories.Filters;
using bookfly.Domain.EstanteLivros.Services.Interfaces;
using bookfly.Domain.Estantes.Entities;
using bookfly.Domain.Estantes.Repositories.Interfaces;
using bookfly.Domain.Livros.Entities;
using bookfly.Domain.Livros.Repositories;
using Mapster;

namespace bookfly.Application.EstanteLivros.Services
{
    public class EstanteLivrosAppService(
        IUnitOfWork wow,
        IEstanteLivrosServices estanteLivrosServices,
        IEstanteRepository estanteRepository,
        ILivrosRepository livrosRepository) : IEstanteLivrosAppServices
    {
        public async Task<EstanteLivroResponse> EditarEstanteLivroAsync(EditarEstanteLivroRequest request, int id, CancellationToken cancellationToken)
        {
            try
            {
                var command = await CriarComandoEditarAsync(request, cancellationToken);
                EstanteLivro estanteLivro = await estanteLivrosServices.ValidarAsync(id, cancellationToken);
                await wow.BeginAsync(cancellationToken);
                estanteLivro = await estanteLivrosServices.EditarEstanteLivroAsync(command, id, cancellationToken);
                await wow.CommitAsync(cancellationToken);

                return estanteLivro.Adapt<EstanteLivroResponse>();
            }
            catch (Exception)
            {
                await wow.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<EstanteLivroResponse> InserirEstanteLivroAsync(InserirEstanteLivroRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = await CriarComandoInserirAsync(request, cancellationToken);

                await wow.BeginAsync(cancellationToken);
                EstanteLivro estanteLivro = await estanteLivrosServices.InserirEstanteLivroAsync(command, cancellationToken);
                await wow.CommitAsync(cancellationToken);

                return estanteLivro.Adapt<EstanteLivroResponse>();
            }
            catch (Exception)
            {
                await wow.RollbackAsync(cancellationToken);
                throw;
            }
        }



        public async Task<List<EstanteLivroResponse>> ListarAsync(ListarEstanteLivroRequest request, CancellationToken cancellationToken)
        {
            var filtro = new EstanteLivroFiltro
            {
                EstanteId = request.EstanteId,
                LivroId = request.LivroId,
                Ativo = request.Ativo,
                StatusLeitura = request.StatusLeitura
            };

            var estanteLivros = await estanteLivrosServices.ListarAsync(filtro, cancellationToken);
            return estanteLivros.Adapt<List<EstanteLivroResponse>>();
        }

        public async Task<EstanteLivroResponse> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            EstanteLivro? estanteLivro = await estanteLivrosServices.ValidarAsync(id, cancellationToken);
            return estanteLivro.Adapt<EstanteLivroResponse>();
        }

        public async Task<EstanteLivroResponse?> ValidarAsync(int livroId, CancellationToken cancellationToken)
        {
            EstanteLivro? estanteLivro = await estanteLivrosServices.ValidarAsync(livroId, cancellationToken);
            return estanteLivro.Adapt<EstanteLivroResponse>();
        }

        private async Task<InserirEstanteLivroCommand> CriarComandoInserirAsync(InserirEstanteLivroRequest request, CancellationToken cancellationToken)
        {
            Estante estante = await RecuperarEstanteAsync(request.EstanteId, cancellationToken);
            Livro livro = await RecuperarLivroAsync(request.LivroId, cancellationToken);

            return new InserirEstanteLivroCommand
            {
                Estante = estante,
                Livro = livro,
                Ativo = request.Ativo,
                StatusLeitura = request.StatusLeitura,
                PaginaAtual = request.PaginaAtual,
                Favorito = request.Favorito,
                IniciadoEm = request.IniciadoEm,
                FinalizadoEm = null
            };
        }

        private async Task<EditarEstanteLivroCommand> CriarComandoEditarAsync(EditarEstanteLivroRequest request, CancellationToken cancellationToken)
        {
            Estante estante = await RecuperarEstanteAsync(request.EstanteId, cancellationToken);
            Livro livro = await RecuperarLivroAsync(request.LivroId, cancellationToken);

            return new EditarEstanteLivroCommand
            {
                Estante = estante,
                Livro = livro,
                Ativo = request.Ativo,
                StatusLeitura = request.StatusLeitura,
                PaginaAtual = request.PaginaAtual,
                Favorito = request.Favorito,
                IniciadoEm = request.IniciadoEm,
                FinalizadoEm = request.FinalizadoEm
            };
        }

        private async Task<Estante> RecuperarEstanteAsync(int estanteId, CancellationToken cancellationToken)
        {
            Estante? estante = await estanteRepository.RecuperarPorIdAsync(estanteId, cancellationToken);

            if (estante is null)
                throw new Exception("Estante não encontrada");

            return estante;
        }

        private async Task<Livro> RecuperarLivroAsync(int livroId, CancellationToken cancellationToken)
        {
            Livro? livro = await livrosRepository.RecuperarPorIdAsync(livroId, cancellationToken);

            if (livro is null)
                throw new Exception("Livro não encontrado");

            return livro;
        }
    }
}
