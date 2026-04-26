


namespace bookfly.Application.Categorias.DataTransfer.Requests
{
    public class ListarCategoriaRequest
    {
        public int? Id { get; set; }

        public string? Nome { get; set; }
        public bool? Situacao { get; set; }
    }
}