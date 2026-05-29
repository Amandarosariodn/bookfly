using bookfly.Application.Estantes.DataTransfer.Requests;
using bookfly.Application.Estantes.DataTransfer.Responses;
using bookfly.Application.Estantes.Services.Interfaces;
using bookfly.Application.Shared.UnitOfWork;
using bookfly.Domain.Estantes.Commands;
using bookfly.Domain.Estantes.Entities;
using bookfly.Domain.Estantes.Repositories.Filters;
using bookfly.Domain.Estantes.Services.Interfaces;
using bookfly.Domain.Usuarios.Entities;
using bookfly.Domain.Usuarios.Repositories;
using Mapster;

namespace bookfly.Application.Estantes.Services
{
    public class EstantesAppService(
        IUnitOfWork unitOfWork,
        IEstantesService estantesService,
        IUsuariosRepository usuariosRepository) : IEstantesAppService
    {
        public async Task<EstanteResponse> EditarAsync(int id, EditarEstanteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                EditarEstanteCommand comando = await CriarComandoEditarAsync(request, cancellationToken);
                await unitOfWork.BeginAsync(cancellationToken);
                Estante estante = await estantesService.EditarEstanteAsync(comando, id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return estante.Adapt<EstanteResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<EstanteResponse> InserirAsync(InserirEstanteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                InserirEstanteCommand comando = await CriarComandoInserirAsync(request, cancellationToken);
                await unitOfWork.BeginAsync(cancellationToken);
                Estante estante = await estantesService.InserirEstanteAsync(comando, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return estante.Adapt<EstanteResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<List<EstanteResponse>> ListarAsync(ListarEstanteRequest request, CancellationToken cancellationToken)
        {
            var estantes = await estantesService.ListarAsync(new EstanteFiltro { Nome = request.Nome }, cancellationToken);
            return estantes.Adapt<List<EstanteResponse>>();
        }

        public async Task MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await unitOfWork.BeginAsync(cancellationToken);
                await estantesService.MudarSituacaoAsync(id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<EstanteResponse> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            Estante estante = await estantesService.ValidarAsync(id, cancellationToken);
            return estante.Adapt<EstanteResponse>();
        }

        private async Task<InserirEstanteCommand> CriarComandoInserirAsync(InserirEstanteRequest request, CancellationToken cancellationToken)
        {
            Usuario usuario = await RecuperarUsuarioAsync(request.UsuarioId, cancellationToken);

            return new InserirEstanteCommand
            {
                UsuarioId = usuario,
                Nome = request.Nome,
                Descricao = request.Descricao,
                Privada = request.Privada
            };
        }

        private async Task<EditarEstanteCommand> CriarComandoEditarAsync(EditarEstanteRequest request, CancellationToken cancellationToken)
        {
            Usuario usuario = await RecuperarUsuarioAsync(request.UsuarioId, cancellationToken);

            return new EditarEstanteCommand
            {
                UsuarioId = usuario,
                Nome = request.Nome,
                Descricao = request.Descricao,
                Privada = request.Privada
            };
        }

        private async Task<Usuario> RecuperarUsuarioAsync(int usuarioId, CancellationToken cancellationToken)
        {
            Usuario usuario = await usuariosRepository.ValidarAsync(usuarioId, cancellationToken);

            if (usuario is null)
                throw new Exception("Usuário não encontrado");

            return usuario;
        }
    }
}
