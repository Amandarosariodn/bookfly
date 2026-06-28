using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookfly.Domain.Comunidades.Repositories.Filters
{
    public class ComunidadeFiltro
    {               
        public string? Nome { get; set; }
        public int? CriadorId { get; set; } 
    }
}