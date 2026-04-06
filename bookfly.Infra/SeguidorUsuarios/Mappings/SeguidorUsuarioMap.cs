using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Domain.SeguidorUsuarios.Entities;
using FluentNHibernate.Mapping;

namespace bookfly.Infra.SeguidorUsuarios.Mappings
{
    public class SeguidorUsuarioMap : ClassMap<SeguidorUsuario>
    {
        public SeguidorUsuarioMap()
        {
            Table("seguidor_usuario");

            CompositeId()
            .KeyProperty(s => s.SeguidorID, "seguidor_id")
            .KeyProperty(s => s.SeguidoID, "seguido_id");
             Map(s => s.CriadoEm).Column("criado_em");



        }

    }
}