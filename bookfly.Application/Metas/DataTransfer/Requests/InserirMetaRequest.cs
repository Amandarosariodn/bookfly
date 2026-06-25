using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookfly.Application.Metas.DataTransfer.Requests
{
    public class InserirMetaRequest
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeMeta { get; set; }
        public int QuantidadeAtual { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
    }
}