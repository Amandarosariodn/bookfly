using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Domain.Enums;

namespace bookfly.Application.Usuarios.DataTransfer.Responses
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string SenhaHash { get; set; }
        public string Biografia { get; set; }
        public string UrlImagem { get; set; }
        public bool ReceberSpoilers { get; set; }
        public AtivoInativoEnum Situacao { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}