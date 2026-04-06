using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookfly.Application.Usuarios.DataTransfer.Requests
{
    public class InserirUsuarioRequest
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string SenhaHash { get; set; }
        public string Biografia { get; set; }
        public string UrlImagem { get; set; }
        public bool ReceberSpoilers { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}