
using bookfly.Application.Categorias.DataTransfer.Requests;
using bookfly.Application.Categorias.DataTransfer.Responses;
using bookfly.Domain.Categorias.Commands;
using bookfly.Domain.Categorias.Entities;
using bookfly.Domain.Enums;
using Mapster;

namespace bookfly.Application.Categorias.Profiles
{
    public class CategoriasProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<InserirCategoriaRequest, InserirCategoriaCommand>();
            config.NewConfig<EditarCategoriaRequest, EditarCategoriaCommand>();
            config.NewConfig<Categoria, CategoriaResponse>();
        }
    }
}