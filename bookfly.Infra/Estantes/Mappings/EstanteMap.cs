
    using bookfly.Domain.Estantes.Entities;
    using FluentNHibernate.Mapping;

    namespace bookfly.Infra.Estantes.Mappings
    {
        public class EstanteMap : ClassMap<Estante>
        {
            public EstanteMap()
            {
                Table("estante");
                Id(estante => estante.Id).Column("id").GeneratedBy.Identity();
                References(estante => estante.UsuarioId).Column("usuario_id").Not.Nullable();
                Map(estante => estante.Nome).Column("nome").Not.Nullable();
                Map(estante => estante.Descricao).Column("descricao").Nullable();
                Map(estante => estante.Privada).Column("privada").CustomType<bool>().Not.Nullable();
                Map(estante => estante.CriadoEm).Column("criado_em").CustomType<DateTime>().Not.Nullable();
            }
        }
    }