

namespace bookfly.Application.Usuarios.DataTransfer.Requests
{
    public class InserirUsuarioRequest
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string Biografia { get; set; }
        public string UrlImagem { get; set; }
        public bool ReceberSpoilers { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
