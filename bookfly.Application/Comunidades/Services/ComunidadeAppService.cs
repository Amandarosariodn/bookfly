
using bookfly.Application.Comunidades.DataTransfer.Requests;
using bookfly.Application.Comunidades.DataTransfer.Responses;
using bookfly.Application.Comunidades.Services.Interfaces;
using bookfly.Application.Shared.UnitOfWork;
using bookfly.Domain.Comunidades.Commands;
using bookfly.Domain.Comunidades.Entities;
using bookfly.Domain.Comunidades.Repositories.Filters;
using bookfly.Domain.Comunidades.Repositories.Interfaces;
using bookfly.Domain.Comunidades.Services.Interfaces;
using Mapster;

namespace bookfly.Application.Comunidades.Services
{
    public class ComunidadeAppService(IComunidadeService comunidadeService, IComunidadeRepository comunidadeRepository, IUnitOfWork unitOfWork) : IComunidadeAppService
    {
        public async Task<ComunidadeResponseDto> EditarAsync(int id, ComunidadeEditarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<ComunidadeEditarCommand>();
                Comunidade comunidade = await comunidadeService.ValidarAsync(id, cancellationToken);
                await unitOfWork.BeginAsync(cancellationToken);
                await comunidadeService.EditarComunidadeAsync(command, id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return comunidade.Adapt<ComunidadeResponseDto>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<ComunidadeResponseDto> InserirAsync(ComunidadeInserirRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<ComunidadeInserirCommand>();

            await unitOfWork.BeginAsync(cancellationToken);
            try
            {
                Comunidade comunidade = await comunidadeService.InserirComunidadeAsync(command, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return comunidade.Adapt<ComunidadeResponseDto>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<List<ComunidadeResponseDto>> ListarAsync(ComunidadeListarRequest request, CancellationToken cancellationToken)
        {
            var estantes = await comunidadeService.ListarAsync(new ComunidadeFiltro { Nome = request.Nome }, cancellationToken);
            return estantes.Adapt<List<ComunidadeResponseDto>>();
        }

        public async Task MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await unitOfWork.BeginAsync(cancellationToken);
                await comunidadeService.MudarSituacaoAsync(id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<ComunidadeResponseDto> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await unitOfWork.BeginAsync(cancellationToken);
                var estante = await comunidadeService.ValidarAsync(id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return estante.Adapt<ComunidadeResponseDto>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}


