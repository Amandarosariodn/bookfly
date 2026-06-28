namespace bookfly.Application.Posts.DataTransfer.Requests
{
    public class InserirPostRequest
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