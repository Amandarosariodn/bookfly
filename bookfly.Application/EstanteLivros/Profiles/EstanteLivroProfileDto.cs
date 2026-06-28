using bookfly.Application.EstanteLivros.DataTransfer.Responses;
using bookfly.Application.Shared;
using bookfly.Domain.EstanteLivros.Entities;
using Mapster;

namespace bookfly.Application.EstanteLivros.Profiles
{
    public class EstanteLivroProfileDto : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<EstanteLivro, EstanteLivroResponseDto>()
                .Map(dest => dest.StatusLeituraText, src => src.StatusLeitura.GetDisplayName());
        }
    }
}
