using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookfly.Application.Posts.DataTransfer.Responses
{
    public class PostResponse
    {
    public int Id{get;set;}
        public long ComunidadeId { get; set; }
        public long AutorId { get; set; }
        public long? LivroId { get; set; }
        public string? Titulo { get; set; }
        public string Conteudo { get; set; }
        public bool ContemSpoiler { get; set; }
        public int? PaginaReferencia { get; set; }
        public bool Fixado { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}