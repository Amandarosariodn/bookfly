

namespace bookfly.Domain.MembrosComunidade.Commands
{
    public class EditarMembroComunidadeCommand
    {
           public virtual int CargoId { get; protected set; }
        public virtual bool Banido { get; protected set; }
    }
}