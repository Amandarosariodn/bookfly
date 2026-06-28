namespace bookfly.Domain.MembrosComunidade.Commands
{
    public class InserirMembroComunidadeCommand
    {
        public  int ComunidadeId { get;  set; }
        public  int UsuarioId { get;  set; }
        public  int CargoId { get;  set; }
        public  bool Banido { get;  set; }
    }
}