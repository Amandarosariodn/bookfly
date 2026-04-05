
using bookfly.Domain.Categorias.Entities;
using bookfly.Domain.Categorias.Services.Interfaces;
using bookfly.Domain.Enums;
using bookfly.Domain.Livros.Commands;
using bookfly.Domain.Livros.Entities;
using bookfly.Domain.Livros.Repositories;
using bookfly.Domain.Livros.Services.Interfaces;

namespace bookfly.Domain.Livros.Services
{
    public class LivrosService(ILivrosRepository livrosRepository, ICategoriasService categoriasService) : ILivrosService
    {
        public async Task<Livro> EditarLivroAsync(EditarLivroCommand comando, int id, CancellationToken cancellationToken)
        {
            Livro livro = await ValidarAsync(id, cancellationToken);

            livro.SetTitulo(comando.Titulo);
            livro.SetAutor(comando.Autor);
            livro.SetSinopse(comando.Sinopse);
            livro.SetTotalPaginas(comando.TotalPaginas);
            livro.SetDataLancamento(comando.DataLancamento);
            livro.SetUrlImagem(comando.UrlImagem);
            livro.SetCategoria(comando.CategoriaId);



            await livrosRepository.EditarAsync(livro, cancellationToken);
            return livro;
        }

        public async Task<Livro> InserirLivroAsync(InserirLivroCommand comando, CancellationToken cancellationToken)
        {
             Livro livro = Instanciar(comando);

            await livrosRepository.InserirAsync(livro, cancellationToken);
            return livro;

        }

        public Livro Instanciar(InserirLivroCommand comando)
        {
            return new Livro(comando.Titulo, comando.Autor, comando.Sinopse, comando.TotalPaginas, comando.DataLancamento, comando.UrlImagem, comando.CategoriaId);
        }


        public async Task AdicionarCategoriaAsync(int livroId, Categoria categoria, CancellationToken cancellationToken)
        {
            var livro = await ValidarAsync(livroId, cancellationToken);

            await categoriasService.ValidarAsync(categoria.Id, cancellationToken);

            livro.SetCategoria(categoria.Id);

            await livrosRepository.EditarAsync(livro, cancellationToken);
        }

        public async Task<List<Livro>> ListarAsync(string titulo, string autor, CancellationToken cancellationToken)
        {
            var livros = await livrosRepository.ListarAsync(titulo, autor, cancellationToken);

            if (livros == null || !livros.Any())
                return new List<Livro>();

            return livros ?? new List<Livro>();
        }

        public async Task<Livro> ValidarAsync(int livroId, CancellationToken cancellationToken)
        {
            Livro? livro = await livrosRepository.RecuperarPorIdAsync(livroId, cancellationToken);

            if (livro == null)
                throw new Exception("Livro não encontrado");

            return livro;
        }

        public async Task MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            Livro livro = await ValidarAsync(id, cancellationToken);

            switch (livro.Situacao)
            {
                case AtivoInativoEnum.Ativo:
                    livro.SetSituacao(AtivoInativoEnum.Inativo);
                    break;
                case AtivoInativoEnum.Inativo:
                    livro.SetSituacao(AtivoInativoEnum.Ativo);
                    break;
            }

            await livrosRepository.EditarAsync(livro, cancellationToken);
        }
    }
}