using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Domain.Comunidades.Enums;

namespace bookfly.Application.Comunidades.DataTransfer.Requests
{
    public class ComunidadeInserirRequest
    {
        public int CriadorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public GeneroComunidadeEnum Genero{get;set;}

        public string UrlImagem { get; set; }
        public bool Privado { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}