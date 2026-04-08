using bookfly.Domain.SeguidorUsuarios.Entities;

namespace bookfly.Domain.SeguidorUsuarios.Services.Interfaces
{
    public interface ISeguidorUsuariosService
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
        Task<List<SeguidorUsuario>> ObterSeguidoresAsync(
        int usuarioId,
        CancellationToken cancellationToken);

        Task<List<SeguidorUsuario>> ObterSeguindoAsync(
        int usuarioId,
        CancellationToken cancellationToken);
    };
}


