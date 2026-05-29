
using bookfly.Domain.EstanteLivros.Enums;
using bookfly.Domain.Estantes.Entities;
using bookfly.Domain.Livros.Entities;

namespace bookfly.Application.EstanteLivros.DataTransfer.Responses
{
    public class EstanteLivroResponse
    {
        public virtual int Id { get; protected set; }
        public virtual Estante Estante { get; protected set; }
        public virtual Livro Livro { get; protected set; }
        public virtual bool Ativo { get; protected set; }
        public virtual StatusLeituraEnum StatusLeitura { get; protected set; }
        public virtual int PaginaAtual { get; protected set; }
        public virtual bool Favorito { get; protected set; }
        public virtual DateTime IniciadoEm { get; protected set; }
        public virtual DateTime? FinalizadoEm { get; protected set; }
        public virtual DateTime CriadoEm { get; protected set; }

    }
}
