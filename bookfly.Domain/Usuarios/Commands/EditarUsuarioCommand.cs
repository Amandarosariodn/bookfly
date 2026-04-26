using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookfly.Domain.Usuarios.Commands
{
    public class EditarUsuarioCommand
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string SenhaHash { get; set; }
        public string Biografia { get; set; }
        public string UrlImagem { get; set; }
        public bool ReceberSpoilers { get; set; }
        public bool Situacao { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}