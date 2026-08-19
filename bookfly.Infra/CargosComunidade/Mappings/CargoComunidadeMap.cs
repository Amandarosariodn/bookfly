using bookfly.Domain.CargosComunidade.Entities;
using FluentNHibernate.Mapping;

namespace bookfly.Infra.CargosComunidade.Mappings
{
    public class CargoComunidadeMap : ClassMap<CargoComunidade>
    {
        public CargoComunidadeMap()
        {
            Table("cargo_comunidade");

            Id(comunidade => comunidade.Id).Column("id").GeneratedBy.Identity();
            References(comunidade => comunidade.ComunidadeId).Column("comunidade_id").Not.Nullable();
            Map(comunidade => comunidade.Nome).Column("nome").Not.Nullable();
            Map(comunidade => comunidade.PodeDeletar).Column("pode_deletar_post").Not.Nullable();
            Map(comunidade => comunidade.PodeBanir).Column("pode_banir_membro").Not.Nullable();
            Map(comunidade => comunidade.PodeFixarPost).Column("pode_fixar_post").Not.Nullable();
            Map(comunidade => comunidade.CriadoEm).Column("criado_em").CustomType<DateTime>().Not.Nullable();
            Map(comunidade=>comunidade.CargoPadrao).Column("cargo_padrao").Not.Nullable();
        }
    }
}