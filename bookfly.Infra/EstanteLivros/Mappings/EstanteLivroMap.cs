using System;
using bookfly.Domain.EstanteLivros.Entities;
using bookfly.Domain.EstanteLivros.Enums;
using FluentNHibernate.Mapping;


namespace bookfly.Infra.EstanteLivros.Mappings
{
    public class EstanteLivroMap : ClassMap<EstanteLivro>
    {
        public EstanteLivroMap()
        {
            Table("estante_livro");
            Id(estanteLivro => estanteLivro.Id).Column("id").GeneratedBy.Identity();
            References(estanteLivro => estanteLivro.Estante).Column("estante_id").Not.Nullable();
            References(estanteLivro => estanteLivro.Livro).Column("livro_id").Not.Nullable();
            Map(estanteLivro => estanteLivro.Situacao).Column("situacao").CustomType<bool>().Not.Nullable();
            Map(estanteLivro => estanteLivro.StatusLeitura).Column("status_leitura").CustomType<StatusLeituraEnum>().Nullable();
            Map(estanteLivro => estanteLivro.PaginaAtual).Column("pagina_atual").Nullable();
            Map(estanteLivro => estanteLivro.Favorito).Column("favorito").CustomType<bool>().Not.Nullable();
            Map(estanteLivro => estanteLivro.IniciadoEm).Column("iniciado_em").CustomType<DateTime>().Nullable();
            Map(estanteLivro => estanteLivro.FinalizadoEm).Column("finalizado_em").CustomType<DateTime>().Nullable();
            Map(estanteLivro => estanteLivro.CriadoEm).Column("criado_em").CustomType<DateTime>().Not.Nullable();

        }
    }
}
