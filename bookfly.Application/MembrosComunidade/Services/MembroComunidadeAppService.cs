using bookfly.Application.MembrosComunidade.DataTransfer.Requests;
using bookfly.Application.MembrosComunidade.DataTransfer.Responses;
using bookfly.Application.MembrosComunidade.Services.Interfaces;
using bookfly.Application.Shared.UnitOfWork;
using bookfly.Domain.MembrosComunidade.Commands;
using bookfly.Domain.MembrosComunidade.Entities;
using bookfly.Domain.MembrosComunidade.Repositories;
using bookfly.Domain.MembrosComunidade.Repositories.Filters;
using bookfly.Domain.MembrosComunidade.Services.Interfaces;
using Mapster;

namespace bookfly.Application.MembrosComunidade.Services
{
    public class MembroComunidadeAppService(IMembrosComunidadeService membrosComunidadeService, IMembrosComunidadeRepository membrosComunidadeRepository, IUnitOfWork unitOfWork) : IMembroComunidadeAppService
    {
        public async Task<MembroComunidadeResponse> EditarAsync(int id, EditarMembroComunidadeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<EditarMembroComunidadeCommand>();
                await unitOfWork.BeginAsync(cancellationToken);
                MembroComunidade membroComunidade = await membrosComunidadeService.EditarMembroComunidadeAsync(command, id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return membroComunidade.Adapt<MembroComunidadeResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<MembroComunidadeResponse> InserirAsync(InserirMembroComunidadeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<InserirMembroComunidadeCommand>();
                await unitOfWork.BeginAsync(cancellationToken);
                MembroComunidade membroComunidade = await membrosComunidadeService.InserirMembroComunidadeAsync(command, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return membroComunidade.Adapt<MembroComunidadeResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<List<MembroComunidadeResponse>> ListarAsync(ListarMembroComunidadeRequest request, CancellationToken cancellationToken)
        {
            List<MembroComunidade> membrosComunidade = await membrosComunidadeService.ListarAsync(new MembroComunidadeFiltro
            {
                ComunidadeId = request.ComunidadeId,
                CargoId = request.CargoId,
                Banido = request.Banido
            }, cancellationToken);

            return membrosComunidade.Adapt<List<MembroComunidadeResponse>>();
        }

        public async Task<MembroComunidadeResponse> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            MembroComunidade membroComunidade = await membrosComunidadeService.ValidarAsync(id, cancellationToken);
            return membroComunidade.Adapt<MembroComunidadeResponse>();
        }
    }
}