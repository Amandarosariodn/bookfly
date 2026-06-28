using System;

namespace bookfly.Domain.Posts.Entities
{
    public class Post
    {
        public virtual long Id { get; protected set; }
        public virtual long ComunidadeId { get; protected set; }
        public virtual long AutorId { get; protected set; }
        public virtual long? LivroId { get; protected set; }
        public virtual string? Titulo { get; protected set; }
        public virtual string Conteudo { get; protected set; }
        public virtual bool ContemSpoiler { get; protected set; }
        public virtual int? PaginaReferencia { get; protected set; }
        public virtual bool Fixado { get; protected set; }
        public virtual DateTime CriadoEm { get; protected set; }

        protected Post() { }

        public Post(long comunidadeId, long autorId, long? livroId, string? titulo, string conteudo, bool contemSpoiler, int? paginaReferencia, bool fixado)
        {
            SetComunidadeId(comunidadeId);
            SetAutorId(autorId);
            SetLivroId(livroId);
            SetTitulo(titulo);
            SetConteudo(conteudo);
            SetContemSpoiler(contemSpoiler);
            SetPaginaReferencia(paginaReferencia);
            SetFixado(fixado);
            CriadoEm = DateTime.UtcNow;
        }

        public virtual void SetComunidadeId(long comunidadeId)
        {
            if (comunidadeId <= 0)
                throw new ArgumentException("O ID da comunidade deve ser maior que zero.", nameof(comunidadeId));

            ComunidadeId = comunidadeId;
        }

        public virtual void SetAutorId(long autorId)
        {
            if (autorId <= 0)
                throw new ArgumentException("O ID do autor deve ser maior que zero.", nameof(autorId));

            AutorId = autorId;
        }

        public virtual void SetLivroId(long? livroId)
        {
            LivroId = livroId;
        }

        public virtual void SetTitulo(string? titulo)
        {
            if (titulo != null && titulo.Length > 255)
                throw new ArgumentException("O título não pode exceder 255 caracteres.", nameof(titulo));

            Titulo = titulo?.Trim();
        }

        public virtual void SetConteudo(string conteudo)
        {
            if (string.IsNullOrWhiteSpace(conteudo))
                throw new ArgumentException("O conteúdo do post não pode ser vazio.", nameof(conteudo));

            Conteudo = conteudo;
        }

        public virtual void SetContemSpoiler(bool contemSpoiler)
        {
            ContemSpoiler = contemSpoiler;
        }

        public virtual void SetPaginaReferencia(int? paginaReferencia)
        {
            if (paginaReferencia.HasValue && paginaReferencia.Value <= 0)
                throw new ArgumentException("A página de referência deve ser maior que zero.", nameof(paginaReferencia));

            PaginaReferencia = paginaReferencia;
        }

        public virtual void SetFixado(bool fixado)
        {
            Fixado = fixado;
        }

        public virtual void SetCriadoEm(DateTime criadoEm)
        {
            if (criadoEm > DateTime.UtcNow)
                throw new ArgumentException("A data de criação não pode ser no futuro.", nameof(criadoEm));

            CriadoEm = criadoEm;
        }
    }
}