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

            Id(meta => meta.Id).Column("id").GeneratedBy.Identity();
            References(meta => meta.UsuarioId).Column("usuario_id").Not.Nullable();
            Map(meta => meta.Nome).Column("nome").Not.Nullable();
            Map(meta => meta.Descricao).Column("descricao").Nullable();
            Map(meta => meta.QuantidadeMeta).Column("quantidade_meta").Not.Nullable();
            Map(meta => meta.QuantidadeAtual).Column("quantidade_atual").Nullable();
            Map(meta => meta.Ano).Column("ano").Not.Nullable();
            Map(meta => meta.CriadoEm).Column("criado_em").CustomType<DateTime>().Not.Nullable();
        }
    }
}