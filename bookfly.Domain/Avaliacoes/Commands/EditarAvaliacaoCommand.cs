
namespace bookfly.Domain.Avaliacoes.Commands
{
    public class EditarAvaliacaoCommand
    {
                public int LivroId { get; protected set; }
        public int Nota { get; protected set; }
        public string? Review { get; protected set; }
    }
}