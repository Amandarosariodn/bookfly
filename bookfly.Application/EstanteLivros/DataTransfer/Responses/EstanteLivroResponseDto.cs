using bookfly.Domain.EstanteLivros.Enums;
using bookfly.Domain.Estantes.Entities;
using bookfly.Domain.Livros.Entities;

namespace bookfly.Application.EstanteLivros.DataTransfer.Responses
{
    public class EstanteLivroResponseDto
    {
        public virtual int Id { get; set; }
        public virtual Estante Estante { get; set; }
        public virtual Livro Livro { get; set; }
        public virtual bool Ativo { get; set; }
        public virtual StatusLeituraEnum StatusLeitura { get; set; }
        public virtual string StatusLeituraText { get; set; }
        public virtual int PaginaAtual { get; set; }
        public virtual bool Favorito { get; set; }
        public virtual DateTime IniciadoEm { get; set; }
        public virtual DateTime? FinalizadoEm { get; set; }
        public virtual DateTime CriadoEm { get; set; }
    }
}
