
using bookfly.Application.Livros.DataTransfer.Requests;
using bookfly.Application.Livros.DataTransfer.Responses;
using bookfly.Application.Livros.Services.Interfaces;
using bookfly.Application.Shared.UnitOfWork;
using bookfly.Domain.Livros.Commands;
using bookfly.Domain.Livros.Entities;
using bookfly.Domain.Livros.Repositories;
using bookfly.Domain.Livros.Repositories.Filters;
using bookfly.Domain.Livros.Services.Interfaces;
using Mapster;

namespace bookfly.Application.Livros.Services
{
    public class LivrosAppServices(ILivrosService livroServices, ILivrosRepository livrosRepository, IUnitOfWork unitOfWork) : ILivrosAppServices
    {
        public async Task<LivroResponse> EditarAsync(int id, EditarLivroRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<EditarLivroCommand>();
                Livro livro = await livroServices.ValidarAsync(id, cancellationToken);
                await unitOfWork.BeginAsync(cancellationToken);
                await livroServices.EditarLivroAsync(command, id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return livro.Adapt<LivroResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<LivroResponse> InserirAsync(InserirLivroRequest request, CancellationToken cancellationToken)
        {
            try
            {
                InserirLivroCommand command = request.Adapt<InserirLivroCommand>();
                await unitOfWork.BeginAsync(cancellationToken);
                Livro livro = await livroServices.InserirLivroAsync(command, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return livro.Adapt<LivroResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<List<LivroResponse>> ListarAsync(ListarLivroRequest request, CancellationToken cancellationToken)
        {
            var livros = await livroServices.ListarAsync(
                request.Titulo,
                request.Autor,
                cancellationToken
        );
            return livros.Adapt<List<LivroResponse>>();
        }

        public async Task MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await unitOfWork.BeginAsync(cancellationToken);
                await livroServices.MudarSituacaoAsync(id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<LivroResponse> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
           Livro livro = await livroServices.ValidarAsync(id, cancellationToken);
            return livro.Adapt<LivroResponse>();
        }
    }
}