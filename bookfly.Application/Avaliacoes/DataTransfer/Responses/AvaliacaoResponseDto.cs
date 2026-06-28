namespace bookfly.Application.Avaliacoes.DataTransfer.Responses
{
    public class AvaliacaoResponseDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public string? NomeLivro { get; set; }
        public int Nota { get; set; }
        public string? Review { get; set; }
        public bool ContemSpoiler { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
