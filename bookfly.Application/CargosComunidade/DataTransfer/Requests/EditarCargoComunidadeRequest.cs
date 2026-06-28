namespace bookfly.Application.CargosComunidade.DataTransfer.Requests
{
    public class EditarCargoComunidadeRequest
    {
        public int ComunidadeId { get; set; }
        public string Nome { get; set; }
        public bool PodeDeletar { get; set; }
        public bool PodeBanir { get; set; }
        public bool PodeFixarPost { get; set; }
    }
}
