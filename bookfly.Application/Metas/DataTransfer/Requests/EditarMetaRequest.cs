

namespace bookfly.Application.Metas.DataTransfer.Requests
{
    public class EditarMetaRequest
    {
             public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeMeta { get; set; }
        public int QuantidadeAtual { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
    }
}