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
            Map(membro => membro.ComunidadeId).Column("comunidade_id").Nullable();
            Map(membro => membro.UsuarioId).Column("usuario_id").Nullable();
            Map(membro => membro.CargoId).Column("cargo_id").Nullable();
            Map(membro => membro.Banido).Column("banido").Nullable();
            Map(membro => membro.EntrouEm).Column("entrou_em").CustomType<DateTime>().Nullable();
        }
    }
}