using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using bookfly.Domain.Posts.Commands;
using bookfly.Domain.Posts.Entities;
using bookfly.Domain.Posts.Repositories.Filters;
using bookfly.Domain.Posts.Repositories.Interfaces;
using bookfly.Domain.Posts.Services.Interfaces;

namespace bookfly.Domain.Posts.Services
{
    public class PostService(IPostRepository postRepository) : IPostService
    {
        public async Task<Post> InserirPostAsync(InserirPostCommand comando, CancellationToken cancellationToken)
        {
            Post post = Instanciar(comando);
            await postRepository.InserirAsync(post, cancellationToken);
            return post;
        }

        public async Task<Post> EditarPostAsync(EditarPostCommand comando, long id, CancellationToken cancellationToken)
        {
            Post post = await ValidarAsync(id, cancellationToken);

            post.SetComunidadeId(comando.ComunidadeId);
            post.SetAutorId(comando.AutorId);
            post.SetLivroId(comando.LivroId);
            post.SetTitulo(comando.Titulo);
            post.SetConteudo(comando.Conteudo);
            post.SetContemSpoiler(comando.ContemSpoiler);
            post.SetPaginaReferencia(comando.PaginaReferencia);
            post.SetFixado(comando.Fixado);

            await postRepository.EditarAsync(post, cancellationToken);
            return post;
        }

        public Post Instanciar(InserirPostCommand comando)
        {
            return new Post(
                comunidadeId: comando.ComunidadeId,
                autorId: comando.AutorId,
                livroId: comando.LivroId,
                titulo: comando.Titulo,
                conteudo: comando.Conteudo,
                contemSpoiler: comando.ContemSpoiler,
                paginaReferencia: comando.PaginaReferencia,
                fixado: comando.Fixado);
        }

        public async Task<List<Post>> ListarAsync(PostFiltro filtro, CancellationToken cancellationToken)
        {
            List<Post> posts = await postRepository.ListarAsync(filtro, cancellationToken);
            return posts ?? new List<Post>();
        }

        public async Task<Post> ValidarAsync(long id, CancellationToken cancellationToken)
        {
            Post? post = await postRepository.RecuperarPorIdAsync(id, cancellationToken);
            if (post is null)
                throw new Exception("Post não encontrado");
            return post;
        }
    }
}