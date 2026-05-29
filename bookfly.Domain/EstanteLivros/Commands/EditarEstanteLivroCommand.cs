using bookfly.Domain.Estantes.Entities;
using bookfly.Domain.EstanteLivros.Enums;
using bookfly.Domain.Livros.Entities;

namespace bookfly.Domain.EstanteLivros.Commands
{
    public class EditarEstanteLivroCommand
    {
        public  int Id { get; set; }
        public  Estante Estante { get; set; }
        public  Livro Livro { get; set; }
        public  bool Ativo { get; set; }
        public  StatusLeituraEnum StatusLeitura { get; set; }
        public  int PaginaAtual { get; set; }
        public  bool Favorito { get; set; }
        public  DateTime IniciadoEm { get; set; }
        public  DateTime? FinalizadoEm { get; set; }

    }
}
