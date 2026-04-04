using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Domain.Enums;

namespace bookfly.Application.Categorias.DataTransfer.Responses
{
    public class CategoriaResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public AtivoInativoEnum Situacao { get; set; }
    }
}