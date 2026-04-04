using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace bookfly.Application.Categorias.DataTransfer.Requests
{
    public class InserirCategoriaRequest
    {
        public string Nome { get; set; }
        public string UrlImagem { get; set; }
        public string Descricao { get; set; }
    }
}