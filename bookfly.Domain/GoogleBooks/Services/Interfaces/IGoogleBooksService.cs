using bookfly.Domain.GoogleBooks.Entities;

namespace bookfly.Domain.GoogleBooks.Services.Interfaces
{
    public interface IGoogleBooksService
    {
        Task<Item?> BuscarPorIdAsync(string googleBooksId, CancellationToken cancellationToken);

        Task<List<Item>> BuscarPorTituloAsync(string titulo, CancellationToken cancellationToken);
    }
}