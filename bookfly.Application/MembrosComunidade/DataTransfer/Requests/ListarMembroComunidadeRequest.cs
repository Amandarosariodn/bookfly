
namespace bookfly.Application.MembrosComunidade.DataTransfer.Requests
{
    public class ListarMembroComunidadeRequest
    {
                public  int? ComunidadeId { get;  set; }
        public  int? CargoId { get;  set; }
        public  bool? Banido { get;  set; }
    }
}