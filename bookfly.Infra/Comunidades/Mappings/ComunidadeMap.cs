

using bookfly.Domain.Comunidades.Entities;
using bookfly.Domain.Comunidades.Enums;
using FluentNHibernate.Mapping;

namespace bookfly.Infra.Comunidades.Mappings
{
    public class ComunidadeMap : ClassMap<Comunidade>
    {
        public ComunidadeMap()
        {
            Table("comunidade");

            Id(comunidade => comunidade.Id).Column("ID").GeneratedBy.Identity();
            Map(comunidade => comunidade.CriadorId).Column("criador_id").Nullable();
            Map(comunidade => comunidade.Nome).Column("nome").Nullable();
            Map(comunidade => comunidade.Descricao).Column("descricao").Nullable();
            Map(comunidade => comunidade.UrlImagem).Column("url_imagem").Nullable();
            Map(comunidade => comunidade.Genero).Column("genero").CustomType<GeneroComunidadeEnum>();
            Map(comunidade => comunidade.Privado).Column("privada").Nullable();
            Map(comunidade => comunidade.Ativo).Column("ativo_inativo").Nullable();
            Map(comunidade => comunidade.DataCriacao).Column("criado_em").CustomType<DateTime>().Nullable();
        }
    }
}