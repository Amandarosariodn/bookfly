
using bookfly.Domain.Estantes.Entities;
using FluentNHibernate.Mapping;

namespace bookfly.Infra.Estantes.Mappings
{
    public class EstanteMap : ClassMap<Estante>
    {
        public EstanteMap()
        {
            Table("estante");
            Id(Estante => Estante.Id).Column("ID").GeneratedBy.Identity();
            Map(Estante => Estante.Nome).Column("nome");
            Map(Estante => Estante.UsuarioId).Column("usuario_id").Not.Nullable();
            Map(Estante => Estante.LivroId).Column("livro_id").Nullable();
            Map(Estante => Estante.Status).Column("status").CustomType<bool>().Nullable();
            Map(Estante => Estante.PaginaAtual).Column("pagina_atual").Nullable();
            Map(Estante => Estante.Favorito).Column("favorito").CustomType<bool>();
            Map(Estante => Estante.IniciadoEm).Column("iniciado_em").Nullable();
            Map(Estante => Estante.FinalizadoEm).Column("finalizado_em").Nullable();
        }
    }
}