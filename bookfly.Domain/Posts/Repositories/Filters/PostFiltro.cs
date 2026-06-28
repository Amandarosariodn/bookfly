namespace bookfly.Domain.Posts.Repositories.Filters
{
    public class PostFiltro
    {
        public long? ComunidadeId { get; set; }
        public long? AutorId { get; set; }
        public long? LivroId { get; set; }
        public bool? Fixado { get; set; }
        public string? Texto { get; set; }
    }
}