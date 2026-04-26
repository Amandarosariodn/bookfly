
using bookfly.Domain.Categorias.Entities;
using FluentNHibernate.Mapping;

namespace bookfly.Infra.Categorias.Mappings
{
    public class CategoriaMap : ClassMap<Categoria>
    {
        public CategoriaMap()
        {
            Table("categoria");

            Id(Categoria => Categoria.Id).Column("ID").GeneratedBy.Identity();
            Map(Categoria => Categoria.Nome).Column("NOME").Not.Nullable();
            Map(categoria => categoria.Descricao).Column("descricao").Nullable();
            Map(categoria => categoria.UrlImagem).Column("url_imagem").Nullable();
            Map(categoria => categoria.Situacao).Column("ativo_inativo").CustomType<bool>().Nullable();
        }
    }
} 