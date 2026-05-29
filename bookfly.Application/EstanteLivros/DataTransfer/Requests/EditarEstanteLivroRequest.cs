using bookfly.Domain.EstanteLivros.Enums;

namespace bookfly.Application.EstanteLivros.DataTransfer.Requests
{
    public class EditarEstanteLivroRequest
    {
        public int EstanteId { get; set; }
        public int LivroId { get; set; }
        public bool Ativo { get; set; }
        public StatusLeituraEnum StatusLeitura { get; set; }
        public int PaginaAtual { get; set; }
        public bool Favorito { get; set; }
        public DateTime IniciadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
    }
}
