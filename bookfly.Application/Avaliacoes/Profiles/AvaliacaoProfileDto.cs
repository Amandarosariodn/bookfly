using bookfly.Application.Avaliacoes.DataTransfer.Responses;
using bookfly.Domain.Avaliacoes.Entities;
using Mapster;

namespace bookfly.Application.Avaliacoes.Profiles
{
    public class AvaliacaoProfileDto : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Avaliacao, AvaliacaoResponseDto>();
        }
    }
}
