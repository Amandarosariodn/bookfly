using bookfly.Domain.Estantes.Entities;
using bookfly.Domain.Livros.Entities;

namespace bookfly.Domain.EstanteLivros.Repositories.Filters
{
    public class EstanteLivroFiltro
    {
        public virtual Estante? Estante { get; protected set; }
        public virtual Livro? Livro { get; protected set; }
    }
}