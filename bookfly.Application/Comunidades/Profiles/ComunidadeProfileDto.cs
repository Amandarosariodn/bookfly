using bookfly.Application.Comunidades.DataTransfer.Responses;
using bookfly.Application.Shared;
using bookfly.Domain.Comunidades.Entities;
using Mapster;

namespace bookfly.Application.Comunidades.Profiles
{
    public class ComunidadeProfileDto : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Comunidade, ComunidadeResponseDto>()
                .Map(dest => dest.GeneroText, src => src.Genero.GetDisplayName());
        }
    }
}
