
namespace bookfly.Domain.Avaliacoes.Commands
{
    public class EditarAvaliacaoCommand
    {
        public int LivroId { get;  set; }
        public int Nota { get;  set; }
        public string? Review { get;  set; }
    }
}