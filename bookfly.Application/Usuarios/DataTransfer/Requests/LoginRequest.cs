namespace bookfly.Application.Usuarios.DataTransfer.Requests
{
    public class LoginRequest
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string Senha { get; set; }
    }
}
