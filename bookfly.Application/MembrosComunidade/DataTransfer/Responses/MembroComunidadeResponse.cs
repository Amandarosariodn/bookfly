

namespace bookfly.Application.MembrosComunidade.DataTransfer.Responses
{
    public class MembroComunidadeResponse
    {
        
        public  int Id { get;  set; }
        public  int ComunidadeId { get;  set; }
        public  int UsuarioId { get;  set; }
        public  int CargoId { get;  set; }
        public  bool Banido { get;  set; }
        public  DateTime EntrouEm { get;  set; }
    }
}