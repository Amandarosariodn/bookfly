

namespace bookfly.Domain.Usuarios.Commands
{
    public class InserirUsuarioCommand
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string SenhaHash { get; set; }
          }
}