using bookfly.Domain.Exceptions;

namespace bookfly.Domain.Avaliacoes.Entities
{
    public class Avaliacao
    {
        public virtual int Id { get;protected set; }
        public virtual int UsuarioId { get; protected set; }
        public virtual int LivroId { get; protected set; }
        public virtual int Nota { get; protected set; }
        public virtual string? Review { get; protected set; }
        public virtual bool ContemSpoiler { get; protected set; }
        public virtual DateTime CriadoEm { get; protected set; }
        
        public Avaliacao()
        {
        }

        public Avaliacao(int usuarioId, int livroId, int nota, string? review, bool contemSpoiler, DateTime criadoEm)
        {
            SetUsuarioId(usuarioId);
            SetLivroId(livroId);
            SetNota(nota);
            SetReview(review);
            SetContemSpoiler(contemSpoiler);
            SetCriadoEm(criadoEm);
        }

        public virtual void SetUsuarioId(int usuarioId)
        {
            if (usuarioId <= 0)
                throw new AtributoInvalidoException(nameof(UsuarioId));

            UsuarioId = usuarioId;
        }

        public virtual void SetLivroId(int livroId)
        {
            if (livroId <= 0)
                throw new AtributoInvalidoException(nameof(LivroId));

            LivroId = livroId;
        }

        public virtual void SetNota(int nota)
        {
            if (nota < 1 || nota > 5)
                throw new TamanhoInvalidoException(nameof(Nota), 1, 5);
            Nota = nota;
        }

        public virtual void SetReview(string? review)
        {
            Review = review;
        }

        public virtual void SetContemSpoiler(bool contemSpoiler)
        {
            ContemSpoiler = contemSpoiler;
        }

        public virtual void SetCriadoEm(DateTime criadoEm)
        {
            CriadoEm = criadoEm;
        }

    }
}