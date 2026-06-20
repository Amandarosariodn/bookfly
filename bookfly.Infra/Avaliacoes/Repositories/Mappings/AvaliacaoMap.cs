using FluentNHibernate.Mapping;
using bookfly.Domain.Avaliacoes.Entities;

namespace bookfly.Infra.Avaliacoes.Repositories.Mappings
{
    public class AvaliacaoMap : ClassMap<Avaliacao>
    {
        public AvaliacaoMap()
        {
            Table("avaliacoes");

            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.UsuarioId).Not.Nullable();
            Map(x => x.LivroId).Not.Nullable();
            Map(x => x.Nota).Not.Nullable();
            Map(x => x.Review).Nullable();
            Map(x => x.ContemSpoiler).Not.Nullable();
        }
    }
}