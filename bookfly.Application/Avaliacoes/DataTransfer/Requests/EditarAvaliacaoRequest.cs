
namespace bookfly.Application.Avaliacoes.DataTransfer.Requests
{
    public class EditarAvaliacaoRequest
    {
        public int LivroId { get; set; }
        public int Nota { get; set; }
        public string? Review { get; set; }
    }
}