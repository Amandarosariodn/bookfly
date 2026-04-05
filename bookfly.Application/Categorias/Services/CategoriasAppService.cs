
using bookfly.Application.Categorias.DataTransfer.Requests;
using bookfly.Application.Categorias.DataTransfer.Responses;
using bookfly.Application.Categorias.Services.Interfaces;
using bookfly.Application.Shared.UnitOfWork;
using bookfly.Domain.Categorias.Commands;
using bookfly.Domain.Categorias.Entities;
using bookfly.Domain.Categorias.Repositories;
using bookfly.Domain.Categorias.Repositories.Filters;
using bookfly.Domain.Categorias.Services.Interfaces;
using Mapster;

namespace bookfly.Application.Categorias.Services
{
    public class CategoriasAppService(ICategoriasRepository categoriasRepository, ICategoriasService categoriasService, IUnitOfWork unitOfWork) : ICategoriasAppService

    {
        public async Task<CategoriaResponse> EditarAsync(int id, EditarCategoriaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<EditarCategoriaCommand>();
                Categoria categoria = await categoriasService.ValidarAsync(id, cancellationToken);
                await unitOfWork.BeginAsync(cancellationToken);
                await categoriasService.EditarCategoriaAsync(command, id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return categoria.Adapt<CategoriaResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<CategoriaResponse> InserirAsync(InserirCategoriaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                InserirCategoriaCommand command = request.Adapt<InserirCategoriaCommand>();
                await unitOfWork.BeginAsync(cancellationToken);
                Categoria categoria = await categoriasService.InserirCategoriaAsync(command, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return categoria.Adapt<CategoriaResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<List<CategoriaResponse>> ListarAsync(ListarCategoriaRequest request,CancellationToken cancellationToken)
        {
            var categorias = await categoriasService.ListarAsync(
                new CategoriaFiltro { Nome = request.Nome },
                cancellationToken);
            return categorias.Adapt<List<CategoriaResponse>>();
        }

        public async Task MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await unitOfWork.BeginAsync(cancellationToken);
                await categoriasService.MudarSituacaoAsync(id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<CategoriaResponse> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            Categoria categoria = await categoriasService.ValidarAsync(id, cancellationToken);
            return categoria.Adapt<CategoriaResponse>();
        }
    }
}