using bookfly.Application.SeguidorUsuarios.DataTransfer.Responses;
using bookfly.Domain.Usuarios.Entities;

namespace bookfly.Application.SeguidorUsuarios.Services.Interfaces
{
    public interface ISeguidorUsuariosAppService
    {
        Task SeguirAsync(
        int seguidorId,
        int seguidoId,
        CancellationToken cancellationToken);

        Task DeixarDeSeguirAsync(
            int seguidorId,
            int seguidoId,
            CancellationToken cancellationToken);

        Task<bool> JaSeguindoAsync(
            int seguidorId,
            int seguidoId,
            CancellationToken cancellationToken);

        // Task<List<SeguidorUsuario>> ListarSeguidoresAsync(CancellationToken cancellationToken);
        Task<List<SeguidorUsuarioResponse>> ObterSeguidoresAsync(
        int usuarioId,
        CancellationToken cancellationToken);

        Task<List<SeguidorUsuarioResponse>> ObterSeguindoAsync(
        int usuarioId,
        CancellationToken cancellationToken);
    }
}