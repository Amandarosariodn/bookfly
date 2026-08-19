using bookfly.Domain.Usuarios.Entities;
using FluentNHibernate.Mapping;

namespace bookfly.Infra.Usuarios.Mappings
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("usuario");

            Id(usuario => usuario.Id).Column("id").GeneratedBy.Identity();
            Map(usuario => usuario.Email).Column("email").Not.Nullable();
            Map(usuario => usuario.Username).Column("username").Not.Nullable();
            Map(usuario => usuario.SenhaHash).Column("senha_hash").Not.Nullable();
            Map(usuario => usuario.Biografia).Column("biografia").Nullable();
            Map(usuario => usuario.UrlImagem).Column("url_imagem").Nullable();
            Map(usuario => usuario.ReceberSpoilers).Column("receber_spoilers").Not.Nullable();
            Map(usuario => usuario.Situacao).Column("ativo_inativo").CustomType<bool>().Not.Nullable();
            Map(usuario => usuario.CriadoEm).Column("criado_em").CustomType<DateTime>().Not.Nullable();
        }
        
    }
}