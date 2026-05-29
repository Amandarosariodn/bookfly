using bookfly.Application.Estantes.DataTransfer.Responses;
using bookfly.Domain.Estantes.Entities;
using Mapster;

namespace bookfly.Application.Estantes.Profiles
{
    public class EstanteProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Estante, EstanteResponse>();
        }
    }
}
