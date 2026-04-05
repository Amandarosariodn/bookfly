using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Domain.Categorias.Entities;

namespace bookfly.Application.Livros.DataTransfer.Requests
{
    public class InserirLivroRequest
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Sinopse { get; set; }
        public int TotalPaginas { get; set; }
        public DateTime DataLancamento { get; set; }
        public string UrlImagem { get; set; }
        public int CategoriaId { get; set; }
    }
}