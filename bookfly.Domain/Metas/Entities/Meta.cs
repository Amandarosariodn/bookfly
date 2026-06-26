

namespace bookfly.Domain.Metas.Entities
{
    public class Meta
    {
        public virtual int Id { get; protected set; }
        public virtual int UsuarioId { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual int QuantidadeMeta { get; protected set; }
        public virtual int QuantidadeAtual { get; protected set; }
        public virtual int Ano { get; protected set; }

        protected Meta()
        {
            
        }

        public Meta(int usuarioId,string nome, string descricao, int quantidadeMeta, int quantidadeAtual, int ano)
        {
            SetUsuarioId(usuarioId);
            SetNome(nome);
            SetDescricao(descricao);
            SetQuantidadeMeta(quantidadeMeta);
            SetQuantidadeAtual(quantidadeAtual);
            SetAno(ano);
        }

        public virtual void SetUsuarioId(int usuarioId)
        {
            if(usuarioId <= 0)
                throw new ArgumentException("O ID do usuário deve ser maior que zero.", nameof(usuarioId));
            
            UsuarioId = usuarioId;
        }

        public virtual void SetNome(string nome)
        {
            if(string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome não pode ser nulo ou vazio.", nameof(nome));
            
            Nome = nome;
        }

        public virtual void SetDescricao(string descricao)
        {
            if(string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("A descrição não pode ser nula ou vazia.", nameof(descricao));
            
            Descricao = descricao;
        }

        public virtual void SetQuantidadeMeta(int quantidadeMeta)
        {
            if(quantidadeMeta < 0)
                throw new ArgumentException("A quantidade da meta não pode ser negativa.", nameof(quantidadeMeta));
            
            QuantidadeMeta = quantidadeMeta;
        }

        public virtual void SetQuantidadeAtual(int quantidadeAtual)
        {
            if(quantidadeAtual < 0)
                throw new ArgumentException("A quantidade atual não pode ser negativa.", nameof(quantidadeAtual));
            
            QuantidadeAtual = quantidadeAtual;
        }

        public virtual void SetAno(int ano)
        {
            if(ano < 0)
                throw new ArgumentException("O ano não pode ser negativo.", nameof(ano));
            
            Ano = ano;
        }



    }
}