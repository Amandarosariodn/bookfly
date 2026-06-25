

namespace bookfly.Application.Metas.DataTransfer.Responses
{
    public class MetaResponse
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeMeta { get; set; }
        public int QuantidadeAtual { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
    }
}