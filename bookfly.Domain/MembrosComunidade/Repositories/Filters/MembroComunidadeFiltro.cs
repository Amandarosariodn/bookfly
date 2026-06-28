

namespace bookfly.Domain.MembrosComunidade.Repositories.Filters
{
    public class MembroComunidadeFiltro
    {
        public virtual int? ComunidadeId { get; protected set; }
        public virtual int? CargoId { get; protected set; }
        public virtual bool? Banido { get; protected set; }

    }
}