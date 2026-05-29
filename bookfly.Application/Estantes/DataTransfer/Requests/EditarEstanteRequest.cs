namespace bookfly.Application.Estantes.DataTransfer.Requests
{
    public class EditarEstanteRequest
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Privada { get; set; }
    }
}
