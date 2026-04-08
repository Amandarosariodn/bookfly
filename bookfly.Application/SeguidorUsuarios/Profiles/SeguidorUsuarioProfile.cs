using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Application.SeguidorUsuarios.DataTransfer.Responses;
using bookfly.Domain.SeguidorUsuarios.Entities;
using Mapster;

namespace bookfly.Application.SeguidorUsuarios.Profiles
{
    public class SeguidorUsuarioProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<SeguidorUsuario, SeguidorUsuarioResponse>();
        }
    }
}