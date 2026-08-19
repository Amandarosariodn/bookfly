using bookfly.Domain.MembrosComunidade.Entities;
using FluentNHibernate.Mapping;

namespace bookfly.Infra.MembrosComunidade.Mappings
{
    public class MembroComunidadeMap : ClassMap<MembroComunidade>
    {
        public MembroComunidadeMap()
        {
            Table("membro_comunidade");

            Id(membro => membro.Id).Column("id").GeneratedBy.Identity();
            References(membro => membro.ComunidadeId).Column("comunidade_id").Not.Nullable();
            References(membro => membro.UsuarioId).Column("usuario_id").Not.Nullable();
            References(membro => membro.CargoId).Column("cargo_id").Not.Nullable();
            Map(membro => membro.Banido).Column("banido").Not.Nullable();
            Map(membro => membro.EntrouEm).Column("entrou_em").CustomType<DateTime>().Not.Nullable();
        }
    }
}