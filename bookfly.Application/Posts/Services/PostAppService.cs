using bookfly.Application.Posts.DataTransfer.Requests;
using bookfly.Application.Posts.DataTransfer.Responses;
using bookfly.Application.Posts.Services.Interfaces;
using bookfly.Application.Shared.UnitOfWork;
using bookfly.Domain.Posts.Commands;
using bookfly.Domain.Posts.Repositories.Filters;
using bookfly.Domain.Posts.Repositories.Interfaces;
using bookfly.Domain.Posts.Services.Interfaces;
using Mapster;

namespace bookfly.Application.Posts.Services
{
    public class PostAppService(IPostService postService, IPostRepository postRepository, IUnitOfWork unitOfWork) : IPostAppService
    {
        public async Task<PostResponse> InserirAsync(InserirPostRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<InserirPostCommand>();
            await unitOfWork.BeginAsync(cancellationToken);

            try
            {
                var post = await postService.InserirPostAsync(command, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return post.Adapt<PostResponse>();
            }
            catch
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<PostResponse> EditarAsync(long id, EditarPostRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<EditarPostCommand>();
            await unitOfWork.BeginAsync(cancellationToken);

            try
            {
                var post = await postService.EditarPostAsync(command, id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return post.Adapt<PostResponse>();
            }
            catch
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<List<PostResponse>> ListarAsync(ListarPostRequest request, CancellationToken cancellationToken)
        {
            var filtro = new PostFiltro
            {
                ComunidadeId = request.ComunidadeId,
                AutorId = request.AutorId,
                LivroId = request.LivroId,
                Fixado = request.Fixado,
                Texto = request.Texto
            };

            var posts = await postService.ListarAsync(filtro, cancellationToken);
            return posts.Adapt<List<PostResponse>>();
        }

        public async Task<PostResponse> RecuperarAsync(long id, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginAsync(cancellationToken);
            try
            {
                var post = await postService.ValidarAsync(id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return post.Adapt<PostResponse>();
            }
            catch
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}