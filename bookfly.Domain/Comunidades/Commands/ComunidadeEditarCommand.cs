

namespace bookfly.Domain.Comunidades.Commands
{
    public class ComunidadeEditarCommand
    {
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual string UrlImagem { get; protected set; }
        public virtual bool Privado { get; protected set; }
        public virtual bool Ativo { get; protected set; }
    }
}