namespace bookfly.Domain.MembrosComunidade.Commands
{
    public class InserirMembroComunidadeCommand
    {
        public virtual int ComunidadeId { get; protected set; }
        public virtual int UsuarioId { get; protected set; }
        public virtual int CargoId { get; protected set; }
        public virtual bool Banido { get; protected set; }
    }
}