using bookfly.Domain.Categorias.Commands;
using bookfly.Domain.Categorias.Entities;
using bookfly.Domain.Categorias.Repositories;
using bookfly.Domain.Categorias.Repositories.Filters;
using bookfly.Domain.Categorias.Services.Interfaces;
using bookfly.Domain.Enums;

namespace bookfly.Domain.Categorias.Services
{
    public class CategoriasService(ICategoriasRepository categoriaRepository) : ICategoriasService
    {
        public async Task<Categoria> EditarCategoriaAsync(EditarCategoriaCommand comando, int id, CancellationToken cancellationToken)
        {
            Categoria categoria = await ValidarAsync(id, cancellationToken);

            categoria.SetNome(comando.Nome);
            categoria.SetDescricao(comando.Descricao);
            categoria.SetUrlImagem(comando.UrlImagem);

            await categoriaRepository.EditarAsync(categoria, cancellationToken);
            return categoria;
        }

        public async Task<Categoria> InserirCategoriaAsync(InserirCategoriaCommand comando, CancellationToken cancellationToken)
        {
            Categoria categoria = Instanciar(comando);


            await categoriaRepository.InserirAsync(categoria, cancellationToken);
            return categoria;

        }

        public Categoria Instanciar(InserirCategoriaCommand comando)
        {
            return new Categoria(comando.Nome, comando.Descricao, comando.UrlImagem);
        }

        public async Task MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            Categoria categoria = await ValidarAsync(id, cancellationToken);

            switch (categoria.Situacao)
            {
                case AtivoInativoEnum.Ativo:
                    categoria.SetSituacao(AtivoInativoEnum.Inativo);
                    break;
                case AtivoInativoEnum.Inativo:
                    categoria.SetSituacao(AtivoInativoEnum.Ativo);
                    break;
            }

            await categoriaRepository.EditarAsync(categoria, cancellationToken);
        }

        public async Task<Categoria> ValidarAsync(int categoriaId, CancellationToken cancellationToken)
        {
            Categoria? categoria = await categoriaRepository.RecuperarPorIdAsync(categoriaId, cancellationToken);

            if (categoria == null)
                throw new Exception("Categoria não encontrado");

            return categoria;
        }

        public async Task<List<Categoria>> ListarAsync(CategoriaFiltro categoria, CancellationToken cancellationToken)
        {
            var categorias = await categoriaRepository.ListarAsync(categoria, cancellationToken);

            if (categorias == null || !categorias.Any())
                return new List<Categoria>();

            return categorias ?? new List<Categoria>();

        }
    }
}