namespace bookfly.Application.Usuarios.Services.Interfaces
{
    public interface ISenhaService
    {
        string GerarHash(string senha);
        bool VerificarSenha(string senha, string senhaHash);
    }
}
