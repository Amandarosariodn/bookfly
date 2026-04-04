
namespace bookfly.Domain.Categorias.Commands
{
    public class ListarCategoriaCommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public string Situacao { get; set; }
    }
}