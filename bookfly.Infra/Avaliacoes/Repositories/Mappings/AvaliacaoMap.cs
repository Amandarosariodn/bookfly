using FluentNHibernate.Mapping;
using bookfly.Domain.Avaliacoes.Entities;

namespace bookfly.Infra.Avaliacoes.Repositories.Mappings
{
    public class AvaliacaoMap : ClassMap<Avaliacao>
    {
        public AvaliacaoMap()
        {
            Table("avaliacao");

            Id(x => x.Id).Column("id").GeneratedBy.Identity();

            Map(x => x.UsuarioId).Column("usuario_id").Not.Nullable();
            Map(x => x.LivroId).Column("livro_id").Not.Nullable();
            Map(x => x.Nota).Column("nota").Not.Nullable();
            Map(x => x.Review).Column("review").Nullable();
            Map(x => x.ContemSpoiler).Column("contem_spoiler").Not.Nullable();


        }
    }
}