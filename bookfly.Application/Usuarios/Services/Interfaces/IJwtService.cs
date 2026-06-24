using bookfly.Domain.Usuarios.Entities;

namespace bookfly.Application.Usuarios.Services.Interfaces
{
    public interface IJwtService
    {
        string GerarToken(Usuario usuario);
        int ValidarToken(string token);
    }
}
