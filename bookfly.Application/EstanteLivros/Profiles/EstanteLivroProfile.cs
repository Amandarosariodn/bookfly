using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Application.EstanteLivros.DataTransfer.Requests;
using bookfly.Application.EstanteLivros.DataTransfer.Responses;
using bookfly.Domain.EstanteLivros.Commands;
using bookfly.Domain.EstanteLivros.Entities;
using Mapster;

namespace bookfly.Application.EstanteLivros.Profiles
{
    public class EstanteLivroProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<EditarEstanteLivroRequest, EditarEstanteLivroCommand>();
            config.NewConfig<InserirEstanteLivroRequest, InserirEstanteLivroCommand>();
            config.NewConfig<EstanteLivro, EstanteLivroResponse>();
        }
    }
}