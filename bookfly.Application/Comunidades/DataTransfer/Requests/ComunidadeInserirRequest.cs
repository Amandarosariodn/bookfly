using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookfly.Application.Comunidades.DataTransfer.Requests
{
    public class ComunidadeInserirRequest
    {
        public int CriadorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public bool Privado { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}