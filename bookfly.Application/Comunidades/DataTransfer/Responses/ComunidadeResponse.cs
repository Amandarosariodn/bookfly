

namespace bookfly.Application.Comunidades.DataTransfer.Responses
{
    public class ComunidadeResponse
    {
         public  int Id { get;  set; }
        public  int CriadorId { get;  set; }
        public  string Nome { get;  set; }
        public  string Descricao { get;  set; }
        public  string UrlImagem { get;  set; }
        public  bool Privado { get;  set; }
        public  bool Ativo { get;  set; }
        public  DateTime DataCriacao { get;  set; }
    }
}