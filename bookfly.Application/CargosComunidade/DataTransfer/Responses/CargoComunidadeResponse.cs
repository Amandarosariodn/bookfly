namespace bookfly.Application.CargosComunidade.DataTransfer.Responses
{
    public class CargoComunidadeResponse
    {
        public int Id { get; set; }
        public int ComunidadeId { get; set; }
        public string Nome { get; set; }
        public bool PodeDeletar { get; set; }
        public bool PodeBanir { get; set; }
        public bool PodeFixarPost { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
