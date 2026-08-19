

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

            Id(comunidade => comunidade.Id).Column("id").GeneratedBy.Identity();
            References(comunidade => comunidade.CriadorId).Column("criador_id").Not.Nullable();
            Map(comunidade => comunidade.Nome).Column("nome").Not.Nullable();
            Map(comunidade => comunidade.Descricao).Column("descricao").Nullable();
            Map(comunidade => comunidade.UrlImagem).Column("url_imagem").Nullable();
            Map(comunidade => comunidade.Genero).Column("genero").CustomType<GeneroComunidadeEnum>();
            Map(comunidade => comunidade.Privado).Column("privada").Not.Nullable();
            Map(comunidade => comunidade.Situacao).Column("situacao").Not.Nullable();
            Map(comunidade => comunidade.DataCriacao).Column("criado_em").CustomType<DateTime>().Not.Nullable();
        }
    }
}