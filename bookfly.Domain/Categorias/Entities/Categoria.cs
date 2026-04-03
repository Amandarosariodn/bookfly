using bookfly.Domain.Enums;

namespace bookfly.Domain.Categorias.Entities
{
    public class Categoria
    {
        public virtual int Id { get; protected set; }
        public virtual string? Nome { get; protected set; }
        public virtual string? Descricao { get; protected set; }
        public virtual string? UrlImagem { get; protected set; }
        public virtual AtivoInativoEnum? Situacao { get; protected set; }

        public Categoria()
        {
        }

        public Categoria(string nome, string descricao, string urlImagem)
        {
            SetNome(nome);
            SetDescricao(descricao);
            SetUrlImagem(urlImagem);
            Ativar();
        }

        public void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("nome não pode ser nulo ou vazio");

            Nome = nome;
        }

        public void SetDescricao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new Exception("descricao não pode ser nula ou vazia");

            Descricao = descricao;
        }

        public void SetUrlImagem(string urlImagem)
        {
            if (string.IsNullOrEmpty(urlImagem))
                throw new Exception("UrlImagem nula ou vazia");

            UrlImagem = urlImagem;
        }

        public void SetSituacao(AtivoInativoEnum situacao)
        {
            if (!Enum.IsDefined(typeof(AtivoInativoEnum), situacao))
                throw new Exception("Situacao");

            Situacao = situacao;
        }

        public virtual void Ativar()
        {
            Situacao = AtivoInativoEnum.Ativo;
        }

    }
}