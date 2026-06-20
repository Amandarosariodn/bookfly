

using bookfly.Application.Avaliacoes.DataTransfer.Requests;
using bookfly.Application.Avaliacoes.DataTransfer.Responses;
using bookfly.Domain.Avaliacoes.Commands;
using bookfly.Domain.Avaliacoes.Entities;
using Mapster;

namespace bookfly.Application.Avaliacoes.Profiles
{
    public class AvaliacaoProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Avaliacao, AvaliacaoResponse>();
            config.NewConfig<InserirAvaliacaoRequest, InserirAvaliacaoCommand>();
            config.NewConfig<EditarAvaliacaoRequest, EditarAvaliacaoCommand>();
        }
    }
}