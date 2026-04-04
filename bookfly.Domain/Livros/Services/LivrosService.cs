
using bookfly.Domain.Livros.Commands;
using bookfly.Domain.Livros.Entities;
using bookfly.Domain.Livros.Repositories;
using bookfly.Domain.Livros.Services.Interfaces;

namespace bookfly.Domain.Livros.Services
{
    public class LivrosService(ILivrosRepository livrosRepository) : ILivrosService
    {
        public Task<Livro> EditarLivroAsync(EditarLivroCommand comando, int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Livro> InserirLivroAsync(InserirLivroCommand comando, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Livro>> ListarAsync(string titulo, string autor, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Livro> RecuperarPorIdAsync(int livroId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}