
using bookfly.Domain.Categorias.Entities;
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
        public virtual DateTime DataLancamento { get; protected set; }
        public virtual string UrlImagem { get; protected set; }
        public virtual int CategoriaId { get; protected set; }
        public virtual AtivoInativoEnum Situacao { get; protected set; }

        public Livro()
        {
        }

        public Livro(string? googleBooksId, string titulo, string autor, string sinopse, int totalPaginas, DateTime dataLancamento, string urlImagem, int categoriaId)
        {
            if (!string.IsNullOrEmpty(googleBooksId))
                SetGoogleBooksId(googleBooksId);

            SetTitulo(titulo);
            SetAutor(autor);
            SetSinopse(sinopse);
            SetTotalPaginas(totalPaginas);
            SetDataLancamento(dataLancamento);
            SetUrlImagem(urlImagem);
            SetCategoria(categoriaId);
            Ativar();
        }



        public virtual void SetGoogleBooksId(string googleBooksId)
        {
            if (string.IsNullOrEmpty(googleBooksId))
                throw new Exception("GoogleBooksId não pode ser nulo");

            GoogleBooksId = googleBooksId;
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

        public virtual void SetDataLancamento(DateTime dataLancamento)
        {
            if (dataLancamento > DateTime.Now)
                throw new Exception("A data de lançamento do livro não pode ser futura");

            DataLancamento = dataLancamento;
        }

        public virtual void SetUrlImagem(string urlImagem)
        {
            if (string.IsNullOrEmpty(urlImagem))
                throw new Exception("A URL da imagem do livro não pode ser nula");

            UrlImagem = urlImagem;
        }

        public virtual void SetCategoria(int categoriaId)
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