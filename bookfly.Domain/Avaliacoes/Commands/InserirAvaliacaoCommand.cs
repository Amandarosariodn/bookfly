
namespace bookfly.Domain.Avaliacoes.Commands
{
    public class InserirAvaliacaoCommand
    {
        public int UsuarioId { get;  set; }
        public int LivroId { get;  set; }
        public int Nota { get;  set; }
        public string? Review { get;  set; }
        public bool ContemSpoiler { get;  set; }
    }
}