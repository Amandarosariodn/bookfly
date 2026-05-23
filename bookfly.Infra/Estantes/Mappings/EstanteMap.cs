
using bookfly.Domain.Estantes.Entities;
using FluentNHibernate.Mapping;

namespace bookfly.Infra.Estantes.Mappings
{
    public class EstanteMap : ClassMap<Estante>
    {
        public EstanteMap()
        {
            Table("estante");
            Id(Estante => Estante.Id).Column("id").GeneratedBy.Identity();
            Map(Estante => Estante.UsuarioId).Column("usuario_id").Not.Nullable();
            Map(Estante => Estante.Nome).Column("nome");
            Map(Estante => Estante.Descricao).Column("descricao").Nullable();
            Map(Estante => Estante.Privada).Column("privada").CustomType<bool>().Nullable();
            Map(Estante => Estante.CriadoEm).Column("criado_em").Nullable();

        }
    }
}