
namespace bookfly.Application.Avaliacoes.DataTransfer.Requests
{
    public class InserirAvaliacaoRequest
    {
        public int LivroId { get; set; }
        public int Nota { get; set; }
        public string? Review { get; set; }
        public bool ContemSpoiler { get; set; }
    }
}
