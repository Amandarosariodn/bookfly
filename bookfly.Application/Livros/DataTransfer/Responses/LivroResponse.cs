using bookfly.Application.Categorias.DataTransfer.Responses;
using bookfly.Domain.Enums;

namespace bookfly.Application.Livros.DataTransfer.Responses
{
    public class LivroResponse
    {
        public virtual int Id { get; protected set; }
        public virtual string GoogleBooksId { get; protected set; }
        public virtual string Titulo { get; protected set; }
        public virtual string Autor { get; protected set; }
        public virtual string Sinopse { get; protected set; }
        public virtual int TotalPaginas { get; protected set; }
        public virtual DateTime DataLancamento { get; protected set; }
        public virtual string UrlImagem { get; protected set; }
        public virtual CategoriaResponse Categoria { get; protected set; }
        public virtual AtivoInativoEnum Situacao { get; protected set; }
    }
}