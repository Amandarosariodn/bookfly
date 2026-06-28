using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Domain.Posts.Entities;
using FluentNHibernate.Mapping;

namespace bookfly.Infra.Posts.Mappings
{
    public class PostMap : ClassMap<Post>
    {
        public PostMap()
        {
            Table("post");

              Id(post => post.Id).Column("ID").GeneratedBy.Identity();
            Map(post => post.ComunidadeId).Column("comunidade_id").Nullable();
            Map(post => post.AutorId).Column("autor_id").Nullable();
            Map(post => post.LivroId).Column("livro_id").Nullable();
            Map(post => post.Titulo).Column("titulo").Nullable();
            Map(post => post.Conteudo).Column("conteudo").Nullable();
            Map(post => post.PaginaReferencia).Column("pagina_referencia").Nullable();
            Map(post => post.Fixado).Column("fixado").Nullable();
            Map(post => post.CriadoEm).Column("criado_em").CustomType<DateTime>().Nullable();
        }
    }
}