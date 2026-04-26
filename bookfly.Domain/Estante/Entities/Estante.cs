using bookfly.Domain.Livros.Entities;
using bookfly.Domain.Usuarios.Entities;

namespace bookfly.Domain.Estante.Entities
{
    public class Estante
    {
        public virtual int Id { get; protected set; }
        public virtual Usuario UsuarioId { get; protected set; }
        public virtual Livro LivroId { get; protected set; }
        public virtual bool Status { get; protected set; }
        public virtual int PaginaAtual { get; protected set; }
        public virtual bool Favorito { get; protected set; }
        public virtual DateTime IniciadoEm { get; protected set; }
        public virtual DateTime FinalizadoEm { get; protected set; }

        public Estante() { }

        public Estante(Usuario usuarioId, Livro livroId, bool status, int paginaAtual, bool favorito, DateTime iniciadoEm, DateTime finalizadoEm)
        {
            SetUsuarioId(usuarioId);
            SetLivroId(livroId);
            Ativar();
            SetPaginaAtual(paginaAtual);
            SetFavorito(favorito);
            SetIniciadoEm(iniciadoEm);
            SetFinalizadoEm(finalizadoEm);
        }

        public virtual void SetUsuarioId(Usuario usuarioId)
        {
            if (usuarioId.Id < 0)
                throw new Exception("Usuário inválido");
            UsuarioId = usuarioId;
        }
        public virtual void SetLivroId(Livro livroId)
        {
            if (livroId.Id < 0)
                throw new Exception("Livro inválido");
            LivroId = livroId;
        }
        public virtual void SetStatus(bool status)
        {
            Status = status;
        }

        public virtual void Ativar()
        {
            Status = true;
        }

        public virtual void SetPaginaAtual(int paginaAtual)
        {
            if (paginaAtual < 0)
                throw new Exception("paginaAtual inválida");
            PaginaAtual = paginaAtual;
        }

        public virtual void SetFavorito(bool favorito)
        {
            Favorito = favorito;
        }
        public virtual void Favoritar()
        {
            Favorito = true;
        }

        public virtual void SetIniciadoEm(DateTime iniciadoEm)
        {
        if(iniciadoEm < DateTime.MinValue || iniciadoEm > DateTime.MaxValue)
                throw new Exception("Data inválida");
            IniciadoEm = DateTime.Now;
        }

        public virtual void SetFinalizadoEm(DateTime finalizadoEm)
        {
            if(finalizadoEm < DateTime.MinValue || finalizadoEm > DateTime.MaxValue)
                throw new Exception("Data inválida");

            FinalizadoEm = finalizadoEm;
        }

    }
}