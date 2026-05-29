using bookfly.Domain.EstanteLivros.Commands;
using bookfly.Domain.EstanteLivros.Entities;
using bookfly.Domain.EstanteLivros.Repositories.Filters;
using bookfly.Domain.EstanteLivros.Repositories.Interfaces;
using bookfly.Domain.EstanteLivros.Services.Interfaces;

namespace bookfly.Domain.EstanteLivros.Services
{
    public class EstanteLivrosServices(IEstanteLivrosRepository repository) : IEstanteLivrosServices
    {
        public async Task<EstanteLivro> EditarEstanteLivroAsync(EditarEstanteLivroCommand comando, int id, CancellationToken cancellationToken)
        {
            EstanteLivro? estanteLivro = await ValidarAsync(id, cancellationToken);
            if (estanteLivro is null)
                throw new Exception("Livro na estante não encontrado");

            estanteLivro.SetEstante(comando.Estante);
            estanteLivro.SetLivro(comando.Livro);
            estanteLivro.SetAtivo(comando.Ativo);
            estanteLivro.SetStatusLeitura(comando.StatusLeitura);
            estanteLivro.SetPaginaAtual(comando.PaginaAtual);
            estanteLivro.SetFavorito(comando.Favorito);
            estanteLivro.SetIniciadoEm(comando.IniciadoEm);
            estanteLivro.SetFinalizadoEm(comando.FinalizadoEm);

            await repository.EditarAsync(estanteLivro, cancellationToken);
            return estanteLivro;

        }

        public async Task<EstanteLivro> InserirEstanteLivroAsync(InserirEstanteLivroCommand comando, CancellationToken cancellationToken)
        {
            EstanteLivro estanteLivro = Instanciar(comando);

            await repository.InserirAsync(estanteLivro, cancellationToken);
            return estanteLivro;
        }

        public EstanteLivro Instanciar(InserirEstanteLivroCommand comando)
        {
            return new EstanteLivro(
                estante: comando.Estante,
                livro: comando.Livro,
                ativo: comando.Ativo,
                statusLeitura: comando.StatusLeitura,
                paginaAtual: comando.PaginaAtual,
                favorito: comando.Favorito,
                iniciadoEm: comando.IniciadoEm,
                finalizadoEm: comando.FinalizadoEm
            );
        }

        public async Task<List<EstanteLivro>> ListarAsync(EstanteLivroFiltro filtro,CancellationToken cancellationToken)
        {
            var estanteLivros = await repository.ListarAsync(filtro, cancellationToken);

            if (estanteLivros == null || !estanteLivros.Any())
                return new List<EstanteLivro>();

            return estanteLivros ?? new List<EstanteLivro>();
        }

        public async Task<EstanteLivro?> ValidarAsync(int estanteLivroId, CancellationToken cancellationToken)
        {
            EstanteLivro? estanteLivro = await repository.RecuperarPorIdAsync(estanteLivroId, cancellationToken);
            if (estanteLivro is null)
                throw new Exception("Livro na estante não encontrado");
            return estanteLivro;
        }

        public async Task AtualizarPaginaAtualAsync(int id, int paginaAtual, CancellationToken cancellationToken)
        {
            EstanteLivro estanteLivro = await ValidarAsync(id, cancellationToken);
            estanteLivro.SetPaginaAtual(paginaAtual);
            await repository.EditarAsync(estanteLivro, cancellationToken);

        }

        

    }
}
