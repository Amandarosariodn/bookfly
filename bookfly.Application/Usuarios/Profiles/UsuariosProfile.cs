
using bookfly.Application.Usuarios.DataTransfer.Requests;
using bookfly.Domain.Usuarios.Commands;
using Mapster;

namespace bookfly.Application.Usuarios.Profiles
{
    public class UsuariosProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<EditarUsuarioRequest, EditarUsuarioCommand>();
            config.NewConfig<InserirUsuarioRequest, InserirUsuarioCommand>();
            config.NewConfig<ListarUsuarioRequest, ListarUsuarioCommand>();
        }
    }
}