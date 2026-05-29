using bookfly.Domain.Usuarios.Entities;

namespace bookfly.Domain.Estantes.Commands
{
    public class InserirEstanteCommand
    {
        public Usuario UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Privada { get; set; }
    }
}
