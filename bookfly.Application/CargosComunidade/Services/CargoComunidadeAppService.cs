using bookfly.Application.CargosComunidade.DataTransfer.Requests;
using bookfly.Application.CargosComunidade.DataTransfer.Responses;
using bookfly.Application.CargosComunidade.Services.Interfaces;
using bookfly.Application.Shared.UnitOfWork;
using bookfly.Domain.CargosComunidade.Commands;
using bookfly.Domain.CargosComunidade.Entities;
using bookfly.Domain.CargosComunidade.Repositories.Filters;
using bookfly.Domain.CargosComunidade.Services.Interfaces;
using Mapster;

namespace bookfly.Application.CargosComunidade.Services
{
    public class CargoComunidadeAppService(
        IUnitOfWork unitOfWork,
        ICargoComunidadeService cargoComunidadeService) : ICargoComunidadeAppService
    {
        public async Task<CargoComunidadeResponse> InserirAsync(InserirCargoComunidadeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<InserirCargoComunidadeCommand>();
                await unitOfWork.BeginAsync(cancellationToken);
                CargoComunidade cargoComunidade = await cargoComunidadeService.InserirCargoComunidadeAsync(command, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return cargoComunidade.Adapt<CargoComunidadeResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<CargoComunidadeResponse> EditarAsync(int id, EditarCargoComunidadeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<EditarCargoComunidadeCommand>();
                await unitOfWork.BeginAsync(cancellationToken);
                CargoComunidade cargoComunidade = await cargoComunidadeService.EditarCargoComunidadeAsync(command, id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return cargoComunidade.Adapt<CargoComunidadeResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<List<CargoComunidadeResponse>> ListarAsync(ListarCargoComunidadeRequest request, CancellationToken cancellationToken)
        {
            List<CargoComunidade> cargosComunidade = await cargoComunidadeService.ListarAsync(new CargoComunidadeFiltro
            {
                ComunidadeId = request.ComunidadeId,
                Nome = request.Nome
            }, cancellationToken);

            return cargosComunidade.Adapt<List<CargoComunidadeResponse>>();
        }

        public async Task<CargoComunidadeResponse> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            CargoComunidade cargoComunidade = await cargoComunidadeService.ValidarAsync(id, cancellationToken);
            return cargoComunidade.Adapt<CargoComunidadeResponse>();
        }
    }
}
