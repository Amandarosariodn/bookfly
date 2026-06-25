using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Domain.Metas.Entities;
using FluentNHibernate.Mapping;

namespace bookfly.Infra.Metas.Mappings
{
    public class MetaMap : ClassMap<Meta>
    {
        public MetaMap()
        {
            Table("meta");

            Id(meta => meta.Id).Column("ID").GeneratedBy.Identity();
            Map(meta => meta.UsuarioId).Column("usuario_id").Nullable();
            Map(meta => meta.Nome).Column("nome").Nullable();
            Map(meta => meta.Descricao).Column("descricao").Nullable();
            Map(meta => meta.QuantidadeMeta).Column("quantidade_meta").Nullable();
            Map(meta => meta.QuantidadeAtual).Column("quantidade_atual").Nullable();
            Map(meta => meta.Ano).Column("ano").Nullable();
            Map(meta => meta.Mes).Column("mes").Nullable();
        }
    }
}