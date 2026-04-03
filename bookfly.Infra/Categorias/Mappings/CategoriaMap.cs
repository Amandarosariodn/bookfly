
using bookfly.Domain.Categorias.Entities;
using bookfly.Domain.Enums;
using FluentNHibernate.Mapping;

namespace bookfly.Infra.Categorias.Mappings
{
    public class CategoriaMap : ClassMap<Categoria>
    {
        public CategoriaMap()
        {
            Table("categoria");

            Id(categoria => categoria.Id).Column("ID").GeneratedBy.Identity();
            Map(categoria => categoria.Nome).Column("NOME").Not.Nullable();
            Map(categoria => categoria.Descricao).Column("descricao").Nullable();
            Map(categoria => categoria.UrlImagem).Column("url_imagem").Nullable();
            Map(categoria => categoria.Situacao).Column("ativo_inativo").CustomType<AtivoInativoEnum>().Nullable();
        }
    }
} 