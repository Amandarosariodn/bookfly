using bookfly.Application.Avaliacoes.DataTransfer.Requests;
using bookfly.Application.Avaliacoes.DataTransfer.Responses;
using bookfly.Application.Avaliacoes.Services.Interfaces;
using bookfly.Application.Shared.UnitOfWork;
using bookfly.Application.Usuarios.DataTransfer.Responses;
using bookfly.Application.Usuarios.Services.Interfaces;
using bookfly.Domain.Avaliacoes.Commands;
using bookfly.Domain.Avaliacoes.Entities;
using bookfly.Domain.Avaliacoes.Repositories;
using bookfly.Domain.Avaliacoes.Repositories.Filters;
using bookfly.Domain.Avaliacoes.Services.Interfaces;
using Mapster;

namespace bookfly.Application.Avaliacoes.Services
{
    public class AvaliacaoAppService(
        IAvaliacaoService avaliacaoService,
        IAvaliacaoRepository avaliacaoRepository,
        IUnitOfWork unitOfWork,
        IUsuariosAppService usuariosAppService) : IAvaliacaoAppService
    {
        public async Task<AvaliacaoResponse> EditarAsync(EditarAvaliacaoRequest request, int id, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<EditarAvaliacaoCommand>();
                Avaliacao avaliacao = await avaliacaoService.ObterPorIdAsync(id, cancellationToken);
                await unitOfWork.BeginAsync(cancellationToken);
                await avaliacaoService.EditarAsync(command, id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return avaliacao.Adapt<AvaliacaoResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task ExcluirAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                Avaliacao avaliacao = await avaliacaoService.ObterPorIdAsync(id, cancellationToken);
                await unitOfWork.BeginAsync(cancellationToken);
                await avaliacaoService.ExcluirAsync(avaliacao, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<AvaliacaoResponse> InserirAsync(
            InserirAvaliacaoRequest request,
            string token,
            CancellationToken cancellationToken)
        {
            try
            {
                UsuarioResponse usuarioLogado = await usuariosAppService.RecuperarUsuarioLogadoAsync(token, cancellationToken);

                InserirAvaliacaoCommand command = request.Adapt<InserirAvaliacaoCommand>();

                command.UsuarioId = usuarioLogado.Id;

                await unitOfWork.BeginAsync(cancellationToken);

                Avaliacao avaliacao = await avaliacaoService.InserirAsync(command, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return avaliacao.Adapt<AvaliacaoResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<IEnumerable<AvaliacaoResponse>> ListarAvaliacoesAsync(ListarAvaliacaoRequest request, CancellationToken cancellationToken)
        {
            var filtro = request.Adapt<AvaliacaoFiltro>();
            var avaliacoes = await avaliacaoService.ListarAvaliacoesAsync(filtro, cancellationToken);
            return avaliacoes.Adapt<List<AvaliacaoResponse>>();
        }

        public async Task<AvaliacaoResponse> ObterPorIdAsync(int id, CancellationToken cancellationToken)
        {
            var avaliacao = await avaliacaoService.ObterPorIdAsync(id, cancellationToken);
            return avaliacao.Adapt<AvaliacaoResponse>();
        }
    }
}
