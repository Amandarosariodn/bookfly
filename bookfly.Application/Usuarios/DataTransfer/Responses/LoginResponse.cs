namespace bookfly.Application.Usuarios.DataTransfer.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UsuarioResponse Usuario { get; set; }
    }
}
