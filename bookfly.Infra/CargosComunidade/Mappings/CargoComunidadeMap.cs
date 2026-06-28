
using System.Threading.Tasks;
using bookfly.Domain.CargosComunidade.Entities;
using FluentNHibernate.Mapping;

namespace bookfly.Infra.CargosComunidade.Mappings
{
    public class CargoComunidadeMap : ClassMap<CargoComunidade>
    {
        public CargoComunidadeMap()
        {
             Table("cargo_comunidade");

            Id(comunidade => comunidade.Id).Column("ID").GeneratedBy.Identity();
            Map(comunidade => comunidade.ComunidadeId).Column("comunidade_id").Nullable();
            Map(comunidade => comunidade.Nome).Column("nome").Nullable();
            Map(comunidade => comunidade.PodeDeletar).Column("pode_deletar_post").Nullable();
            Map(comunidade => comunidade.PodeBanir).Column("pode_banir_membro").Nullable();
            Map(comunidade => comunidade.PodeFixarPost).Column("pode_fixar_post").Nullable();
            Map(comunidade => comunidade.CriadoEm).Column("criado_em").CustomType<DateTime>().Nullable();
        }
    }
}