using bookfly.Application.SeguidorUsuarios.DataTransfer.Responses;
using bookfly.Application.SeguidorUsuarios.Services.Interfaces;
using bookfly.Application.Shared.UnitOfWork;
using bookfly.Domain.SeguidorUsuarios.Entities;
using bookfly.Domain.SeguidorUsuarios.Repositories;
using bookfly.Domain.SeguidorUsuarios.Services.Interfaces;
using Mapster;

namespace bookfly.Application.SeguidorUsuarios.Services
{
    public class SeguidorUsuarioAppService(ISeguidorUsuariosService seguidorUsuariosService, ISeguidorUsuarioRepository seguidorUsuarioRepository, IUnitOfWork unitOfWork) : ISeguidorUsuariosAppService
    {
        public async Task DeixarDeSeguirAsync(int seguidorId, int seguidoId, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginAsync(cancellationToken);

            try
            {
                await seguidorUsuariosService.DeixarDeSeguirAsync(seguidorId, seguidoId, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<bool> JaSeguindoAsync(int seguidorId, int seguidoId, CancellationToken cancellationToken)
        {
            return await seguidorUsuariosService.JaSeguindoAsync(seguidorId, seguidoId, cancellationToken);
        }

        public async Task<List<SeguidorUsuarioResponse>> ObterSeguidoresAsync(int usuarioId, CancellationToken cancellationToken)
        {

            List<SeguidorUsuario> seguidores =
        await seguidorUsuariosService.ObterSeguidoresAsync(usuarioId, cancellationToken);

            return seguidores.Adapt<List<SeguidorUsuarioResponse>>();

        }

        public async Task<List<SeguidorUsuarioResponse>> ObterSeguindoAsync(int usuarioId, CancellationToken cancellationToken)
        {
            List<SeguidorUsuario> seguindo =
       await seguidorUsuariosService.ObterSeguindoAsync(usuarioId, cancellationToken);

            return seguindo.Adapt<List<SeguidorUsuarioResponse>>();
        }

        public async Task SeguirAsync(int seguidorId, int seguidoId, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginAsync(cancellationToken);

            try
            {
                await seguidorUsuariosService.SeguirAsync(seguidorId, seguidoId, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}