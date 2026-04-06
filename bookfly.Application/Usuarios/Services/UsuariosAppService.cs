using bookfly.Application.Shared.UnitOfWork;
using bookfly.Application.Usuarios.DataTransfer.Requests;
using bookfly.Application.Usuarios.DataTransfer.Responses;
using bookfly.Application.Usuarios.Services.Interfaces;
using bookfly.Domain.Usuarios.Commands;
using bookfly.Domain.Usuarios.Entities;
using bookfly.Domain.Usuarios.Repositories;
using bookfly.Domain.Usuarios.Repositories.Filters;
using bookfly.Domain.Usuarios.Services.Interfaces;
using Mapster;

namespace bookfly.Application.Usuarios.Services
{
    public class UsuariosAppService(IUsuariosServices usuariosServices, IUsuariosRepository usuariosRepository, IUnitOfWork unitOfWork) : IUsuariosAppService
    {
        public async Task<UsuarioResponse> EditarAsync(int id, EditarUsuarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var comando = request.Adapt<EditarUsuarioCommand>();
                Usuario usuario = await usuariosServices.ValidarAsync(id, cancellationToken);
                await unitOfWork.BeginAsync(cancellationToken);
                await usuariosServices.EditarAsync(comando, id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return usuario.Adapt<UsuarioResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<UsuarioResponse> InserirAsync(InserirUsuarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                InserirUsuarioCommand comando = request.Adapt<InserirUsuarioCommand>();
                await unitOfWork.BeginAsync(cancellationToken);
                Usuario usuario = await usuariosServices.InserirAsync(comando, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return usuario.Adapt<UsuarioResponse>();
            }
            catch(Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<List<UsuarioResponse>> ListarAsync(ListarUsuarioRequest request, CancellationToken cancellationToken)
        {
            var usuarios = await usuariosServices.ListarAsync(new UsuarioFiltro {Username = request.Username}, cancellationToken);
            return usuarios.Adapt<List<UsuarioResponse>>();
        }

        public async Task MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await unitOfWork.BeginAsync(cancellationToken);
                await usuariosServices.MudarSituacaoAsync(id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<UsuarioResponse> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            Usuario usuario = await usuariosServices.ValidarAsync(id, cancellationToken);
            return usuario.Adapt<UsuarioResponse>();
        }
    }
}