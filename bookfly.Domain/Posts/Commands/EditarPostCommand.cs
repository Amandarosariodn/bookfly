namespace bookfly.Domain.Posts.Commands
{
    public class EditarPostCommand
    {
        public long ComunidadeId { get; set; }
        public long AutorId { get; set; }
        public long? LivroId { get; set; }
        public string? Titulo { get; set; }
        public string Conteudo { get; set; }
        public bool ContemSpoiler { get; set; }
        public int? PaginaReferencia { get; set; }
        public bool Fixado { get; set; }
    }
}