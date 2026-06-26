
namespace bookfly.Domain.Metas.Commands
{
    public class InserirMetaCommand
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeMeta { get; set; }
        public int QuantidadeAtual { get; set; }
        public int Ano { get; set; }
    }
}