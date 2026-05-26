using bookfly.Domain.Estantes.Entities;
using bookfly.Domain.Livros.Entities;

namespace bookfly.Domain.EstanteLivros.Commands
{
    public class EditarEstanteLivroCommand
    {
        public  int Id { get; set; }
        public  Estante Estante { get; set; }
        public  Livro Livro { get; set; }
        public  bool Status { get; set; }
        public  int PaginaAtual { get; set; }
        public  bool Favorito { get; set; }
        public  DateTime IniciadoEm { get; set; }

    }
}