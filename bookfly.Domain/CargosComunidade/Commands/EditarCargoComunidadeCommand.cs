namespace bookfly.Domain.CargosComunidade.Commands
{
    public class EditarCargoComunidadeCommand
    {
        public int ComunidadeId { get; set; }
        public string Nome { get; set; }
        public bool PodeDeletar { get; set; }
        public bool PodeBanir { get; set; }
        public bool PodeFixarPost { get; set; }
    }
}
