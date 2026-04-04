using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Domain.Categorias.Entities;

namespace bookfly.Domain.Livros.Commands
{
    public class EditarLivroCommand
    {
        
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Sinopse { get; set; }
        public int TotalPaginas { get; set; }
        public DateOnly DataLancamento { get; set; }
        public string UrlImagem { get; set; }
        public Categoria Categoria { get; set; }
    }
}