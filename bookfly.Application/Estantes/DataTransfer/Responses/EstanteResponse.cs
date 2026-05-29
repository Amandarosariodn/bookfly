using bookfly.Domain.Usuarios.Entities;

namespace bookfly.Application.Estantes.DataTransfer.Responses
{
    public class EstanteResponse
    {
        public int Id { get; protected set; }
        public Usuario UsuarioId { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public bool Privada { get; protected set; }
        public DateTime CriadoEm { get; protected set; }
    }
}
