
namespace bookfly.Application.MembrosComunidade.DataTransfer.Requests
{
    public class EditarMembroComunidadeRequest
    {
                   public virtual int CargoId { get; protected set; }
        public virtual bool Banido { get; protected set; }
    }
}