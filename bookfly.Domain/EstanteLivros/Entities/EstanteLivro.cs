using bookfly.Domain.EstanteLivros.Enums;
using bookfly.Domain.Estantes.Entities;
using bookfly.Domain.Livros.Entities;

namespace bookfly.Domain.EstanteLivros.Entities
{
    public class EstanteLivro
    {
        public virtual int Id { get; protected set; }
        public virtual Estante Estante { get; protected set; }
        public virtual Livro Livro { get; protected set; }
        public virtual bool Situacao { get; protected set; }
        public virtual StatusLeituraEnum StatusLeitura  { get; protected set; }
        public virtual int PaginaAtual { get; protected set; }
        public virtual bool Favorito { get; protected set; }
        public virtual DateTime IniciadoEm { get; protected set; }
        public virtual DateTime? FinalizadoEm { get; protected set; }
        public virtual DateTime CriadoEm { get; protected set; }

        protected EstanteLivro()
        {
        }

        public EstanteLivro(Estante estante, Livro livro, bool situacao, StatusLeituraEnum statusLeitura, int paginaAtual, bool favorito, DateTime iniciadoEm, DateTime? finalizadoEm)
        {
            SetEstante(estante);
            SetLivro(livro);
            SetSituacao(situacao);
            SetStatusLeitura(statusLeitura);
            SetPaginaAtual(paginaAtual);
            SetFavorito(favorito);
            SetIniciadoEm(iniciadoEm);
            SetFinalizadoEm(finalizadoEm);
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

        public virtual void SetSituacao(bool situacao)
        {
            Situacao = situacao;
        }

        public virtual void SetStatusLeitura(StatusLeituraEnum statusLeitura)
        {
            if (!Enum.IsDefined(typeof(StatusLeituraEnum), statusLeitura))
                throw new Exception("Status de leitura inválido");

            StatusLeitura = statusLeitura;
        }

        public virtual void SetPaginaAtual(int paginaAtual)
        {
            if (paginaAtual < 0)
                throw new Exception("Página atual não pode ser negativa");

            if (Livro != null && paginaAtual > Livro.TotalPaginas)
                throw new Exception("Página atual não pode ser maior que o total de páginas do livro");

            PaginaAtual = paginaAtual;
        }
        public virtual void SetFavorito(bool favorito)
        {
            Favorito = favorito;
        }
        public virtual void SetIniciadoEm(DateTime iniciadoEm)
        {
            if (iniciadoEm > DateTime.Now)
                throw new Exception("Data de início não pode ser futura");

            IniciadoEm = iniciadoEm;
        }

        public virtual void SetFinalizadoEm(DateTime? finalizadoEm)
        {
            if (finalizadoEm.HasValue && finalizadoEm.Value > DateTime.Now)
                throw new Exception("Data de finalização não pode ser futura");

            if (finalizadoEm.HasValue && IniciadoEm != default && finalizadoEm.Value < IniciadoEm)
                throw new Exception("Data de finalização não pode ser anterior à data de início");

            FinalizadoEm = finalizadoEm;
        }

        public virtual void SetCriadoEm(DateTime criadoEm)
        {
            if (criadoEm > DateTime.Now)
                throw new Exception("Data de criação não pode ser futura");

            CriadoEm = criadoEm;
        }
    }
}
