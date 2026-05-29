using bookfly.Domain.EstanteLivros.Enums;

namespace bookfly.Application.EstanteLivros.DataTransfer.Requests
{
    public class ListarEstanteLivroRequest
    {
        public int? EstanteId { get; set; }
        public int? LivroId { get; set; }
        public bool? Ativo { get; set; }
        public StatusLeituraEnum? StatusLeitura { get; set; }
    }
}
