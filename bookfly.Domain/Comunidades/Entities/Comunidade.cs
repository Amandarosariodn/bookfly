

namespace bookfly.Domain.Comunidades.Entities
{
    public class Comunidade
    {
        public virtual int Id { get; protected set; }
        public virtual int CriadorId { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual string UrlImagem { get; protected set; }
        public virtual bool Privado { get; protected set; }
        public virtual bool Ativo { get; protected set; }
        public virtual DateTime DataCriacao { get; protected set; }
        
        protected Comunidade() { }

        public Comunidade(int criadorId, string nome, string descricao, string urlImagem, bool privado)
        {
            SetCriadorId(criadorId);
            SetNome(nome);
            SetDescricao(descricao);
            SetUrlImagem(urlImagem);
            SetPrivado(privado);

            DataCriacao = DateTime.Now;

            Ativar();
        }

        public virtual void SetCriadorId(int criadorId)
        {

            if (criadorId <= 0)
            {
                throw new ArgumentException("O ID do criador deve ser maior que zero.", nameof(criadorId));
            }
            CriadorId = criadorId;
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome não pode ser nulo ou vazio.", nameof(nome));
            }
            Nome = nome;
        }

        public virtual void SetDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentException("A descrição não pode ser nula ou vazia.", nameof(descricao));
            }
            Descricao = descricao;
        }

        public virtual void SetUrlImagem(string urlImagem)
        {
            if (string.IsNullOrWhiteSpace(urlImagem))
            {
                throw new ArgumentException("A URL da imagem não pode ser nula ou vazia.", nameof(urlImagem));
            }
            UrlImagem = urlImagem;
        }

        public virtual void SetPrivado(bool privado)
        {
            Privado = privado;
        }

        public virtual void SetAtivo(bool ativo)
        {
            Ativo = ativo;
        }

        public virtual void SetDataCriacao(DateTime dataCriacao)
        {
            dataCriacao = DateTime.Now;

            DataCriacao = dataCriacao;
        }

        public virtual void Ativar()
        {
            Ativo = true;
        }
    }
}