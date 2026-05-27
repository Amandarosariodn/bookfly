using bookfly.Domain.Estantes.Entities;
using bookfly.Domain.Livros.Entities;

namespace bookfly.Domain.EstanteLivros.Entities
{
    public class EstanteLivro
    {
        public virtual int Id { get; protected set; }
        public virtual Estante Estante { get; protected set; }
        public virtual Livro Livro { get; protected set; }
        public virtual bool Status { get; protected set; }
    //    public virtual StatusLeituraEnum StatusLeitura  { get; protected set; }
        public virtual int PaginaAtual { get; protected set; }
        public virtual bool Favorito { get; protected set; }
        public virtual DateTime IniciadoEm { get; protected set; }
        public virtual DateTime FinalizadoEm { get; protected set; }
        public virtual DateTime CriadoEm { get; protected set; }

        protected EstanteLivro()
        {
        }

        public EstanteLivro(Estante estante, Livro livro, bool status, int paginaAtual, bool favorito, DateTime iniciadoEm)
        {
            SetEstante(estante);
            SetLivro(livro);
            SetStatus(status);
            SetPaginaAtual(paginaAtual);
            SetFavorito(favorito);
            SetIniciadoEm(iniciadoEm);
            CriadoEm = DateTime.Now;
        }

        public virtual void SetEstante(Estante estante)
        {
            if (estante == null)
            {
                throw new ArgumentNullException(nameof(estante));
            }
            Estante = estante;
        }

        public virtual void SetLivro(Livro livro)
        {
            if (livro == null)
            {
                throw new ArgumentNullException(nameof(livro));
            }
            Livro = livro;
        }

        public virtual void SetStatus(bool status)
        {
            Status = status;
        }
        public virtual void SetPaginaAtual(int paginaAtual)
        {
            if (paginaAtual < 0)
                throw new ArgumentOutOfRangeException(nameof(paginaAtual));
            PaginaAtual = paginaAtual;
        }
        public virtual void SetFavorito(bool favorito)
        {
            Favorito = favorito;
        }
        public virtual void SetIniciadoEm(DateTime iniciadoEm)
        {
            IniciadoEm = iniciadoEm;
        }
        public virtual void SetFinalizadoEm(DateTime finalizadoEm)
        {
            FinalizadoEm = finalizadoEm;
        }
        public virtual void SetCriadoEm(DateTime criadoEm)
        {
            CriadoEm = criadoEm;
        }
    }
}