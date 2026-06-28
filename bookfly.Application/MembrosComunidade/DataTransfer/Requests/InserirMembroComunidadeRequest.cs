
namespace bookfly.Application.MembrosComunidade.DataTransfer.Requests
{
    public class InserirMembroComunidadeRequest
    {
                public  int ComunidadeId { get;  set; }
        public  int UsuarioId { get;  set; }
        public  int CargoId { get;  set; }
        public  bool Banido { get;  set; }
    }
}