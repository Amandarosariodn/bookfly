using bookfly.Domain.SeguidorUsuarios.Entities;

namespace bookfly.Domain.SeguidorUsuarios.Repositories
{
    public interface ISeguidorUsuarioRepository
    {
        Task SeguirAsync(SeguidorUsuario seguidor, CancellationToken cancellationToken);
        Task DeixarDeSeguirAsync(int seguidorId, int seguindoId, CancellationToken cancellationToken);
        Task<bool> JaSeguindoAsync(int seguidorId, int seguindoId, CancellationToken cancellationToken);
        Task<IReadOnlyList<int>> ObterSeguidoresAsync(int usuarioId, CancellationToken cancellationToken);
        Task<IReadOnlyList<int>> ObterSeguindoAsync(int usuarioId, CancellationToken cancellationToken);
        Task<int> ContarSeguidoresAsync(int usuarioId, CancellationToken cancellationToken);
        Task<int> ContarSeguindoAsync(int usuarioId, CancellationToken cancellationToken);
    }
}