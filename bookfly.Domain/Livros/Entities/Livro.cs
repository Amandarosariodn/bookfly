
using bookfly.Domain.Enums;

namespace bookfly.Domain.Livros.Entities
{
    public class Livro
    {
        public virtual int Id { get; protected set; }
        public virtual string GoogleBooksId { get; protected set; }
        public virtual string Titulo { get; protected set; }
        public virtual string Autor { get; protected set; }
        public virtual string Sinopse { get; protected set; }
        public virtual int TotalPaginas { get; protected set; }
        public virtual DateOnly DataLancamento { get; protected set; }
        public virtual string UrlImagem { get; protected set; }
        public virtual int CategoriaId { get; protected set; }
        public virtual AtivoInativoEnum Situacao { get; protected set; }

        public Livro()
        {
        }

        public Livro(string titulo, string autor, string sinopse, int totalPaginas, DateOnly dataLancamento, string urlImagem, int categoriaId)
        {
            SetTitulo(titulo);
            SetAutor(autor);
            SetSinopse(sinopse);
            SetTotalPaginas(totalPaginas);
            SetDataLancamento(dataLancamento);
            SetUrlImagem(urlImagem);
            SetCategoriaId(categoriaId);
            Ativar();
        }
        

        

        public virtual void SetTitulo(string titulo)
        {
            if (string.IsNullOrEmpty(titulo))
                throw new Exception("O Título do livro não pode ser nulo");

            Titulo = titulo;
        }
        public virtual void SetAutor(string autor)
        {
            if (string.IsNullOrEmpty(autor))
                throw new Exception("O autor do livro não pode ser nulo");

            Autor = autor;
        }

        public virtual void SetSinopse(string sinopse)
        {
            if (string.IsNullOrEmpty(sinopse))
                throw new Exception("A sinopse do livro não pode ser nula");

            Sinopse = sinopse;
        }

        public virtual void SetTotalPaginas(int totalPaginas)
        {
            if (totalPaginas <= 0)
                throw new Exception("O total de páginas do livro deve ser maior que zero");

            TotalPaginas = totalPaginas;
        }

        public virtual void SetDataLancamento(DateOnly dataLancamento)
        {
            if (dataLancamento > DateOnly.FromDateTime(DateTime.Now))
                throw new Exception("A data de lançamento do livro não pode ser futura");

            DataLancamento = dataLancamento;
        }

        public virtual void SetUrlImagem(string urlImagem)
        {
            if (string.IsNullOrEmpty(urlImagem))
                throw new Exception("A URL da imagem do livro não pode ser nula");

            UrlImagem = urlImagem;
        }

        public virtual void SetCategoriaId(int categoriaId)
        {
            if (categoriaId <= 0)
                throw new Exception("O ID da categoria do livro deve ser maior que zero");

            CategoriaId = categoriaId;
        }

        public virtual void SetSituacao(AtivoInativoEnum situacao)
        {
            if (!Enum.IsDefined(typeof(AtivoInativoEnum), situacao))
                throw new Exception("Situacao");

            Situacao = situacao;
        }

        public virtual void Ativar()
        {
            Situacao = AtivoInativoEnum.Ativo;
        }
    }
}