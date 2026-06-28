
using bookfly.Domain.Comunidades.Enums;

namespace bookfly.Domain.Comunidades.Commands
{
    public class ComunidadeInserirCommand
    {
        public  int CriadorId { get;  set; }
        public  string Nome { get;  set; }
        public  string Descricao { get;  set; }
        public GeneroComunidadeEnum Genero{get;set;}
        public  string UrlImagem { get;  set; }
        public  bool Privado { get;  set; }
        public  bool Ativo { get;  set; }
        public  DateTime DataCriacao { get;  set; }
    }
}