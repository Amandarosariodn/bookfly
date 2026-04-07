using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookfly.Domain.GoogleBooks.Commands
{
    public class InserirLivroViaGoogleCommand
    {
        public string GoogleBooksId { get; set; }

        public int CategoriaId { get; set; }
    }

}