

namespace bookfly.Domain.Metas.Commands
{
    public class EditarMetaCommand
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeMeta { get; set; }
        public int QuantidadeAtual { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
    }
}