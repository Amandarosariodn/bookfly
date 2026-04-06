using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Application.Usuarios.DataTransfer.Requests;
using bookfly.Application.Usuarios.DataTransfer.Responses;

namespace bookfly.Application.Usuarios.Services.Interfaces
{
    public interface IUsuariosAppService
    {
        Task MudarSituacaoAsync(int id, CancellationToken cancellationToken);
        Task<UsuarioResponse> EditarAsync(int id, EditarUsuarioRequest request, CancellationToken cancellationToken);
        Task<UsuarioResponse> RecuperarAsync(int id, CancellationToken cancellationToken);
        Task<UsuarioResponse> InserirAsync(InserirUsuarioRequest request, CancellationToken cancellationToken);
        Task<List<UsuarioResponse>> ListarAsync(ListarUsuarioRequest request, CancellationToken cancellationToken);
    }
}