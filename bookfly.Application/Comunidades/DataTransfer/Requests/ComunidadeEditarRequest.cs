namespace bookfly.Application.Comunidades.DataTransfer.Requests
{
    public class ComunidadeEditarRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public bool Privado { get; set; }
        public bool Ativo { get; set; }
    }
}