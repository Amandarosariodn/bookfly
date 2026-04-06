
using bookfly.Domain.Enums;
using bookfly.Domain.Usuarios.Entities;
using FluentNHibernate.Mapping;

namespace bookfly.Infra.Usuarios.Mappings
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("usuario");

            Id(usuario => usuario.Id).Column("ID").GeneratedBy.Identity();
            Map(usuario => usuario.Email).Column("email");
            Map(usuario => usuario.Username).Column("username");
            Map(usuario => usuario.SenhaHash).Column("senha_hash");
            Map(usuario => usuario.Biografia).Column("biografia").Nullable();
            Map(usuario => usuario.UrlImagem).Column("url_imagem").Nullable();
            Map(usuario => usuario.ReceberSpoilers).Column("receber_spoilers").Nullable();
            Map(usuario => usuario.Situacao).Column("ativo_inativo").CustomType<AtivoInativoEnum>().Nullable();
            Map(usuario => usuario.CriadoEm).Column("criado_em");
        }
        
    }
}