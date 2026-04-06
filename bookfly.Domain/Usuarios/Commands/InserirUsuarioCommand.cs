
namespace bookfly.Domain.Usuarios.Commands
{
    public class InserirUsuarioCommand
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string SenhaHash { get; set; }
        public string Biografia { get; set; }
        public string UrlImagem { get; set; }
        public bool ReceberSpoilers { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}