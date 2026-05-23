using bookfly.Domain.Livros.Entities;
using bookfly.Domain.Usuarios.Entities;

namespace bookfly.Domain.Estantes.Entities
{
    public class Estante
    {
        public virtual int Id { get; protected set; }
        public virtual Usuario UsuarioId { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual bool Privada { get; protected set; }
        public virtual DateTime CriadoEm { get; protected set; }

        public Estante() { }

        public Estante(Usuario usuarioId, string nome, string descricao, bool privada, DateTime criadoEm)
        {
            SetUsuarioId(usuarioId);
            SetNome(nome);
            SetDescricao(descricao);
            SetPrivada(privada);
            SetCriadoEm(criadoEm);
        }
        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("nome não pode ser nulo ou vazio");

            Nome = nome;
        }
        public virtual void SetDescricao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new Exception("Descricao não pode ser nulo ou vazio");

            Descricao = descricao;
        }

        public virtual void SetUsuarioId(Usuario usuarioId)
        {
            if (usuarioId.Id < 0)
                throw new Exception("Usuário inválido");
            UsuarioId = usuarioId;
        }


        public virtual void SetPrivada(bool privada)
        {
            Privada = privada;
        }


        public virtual void SetCriadoEm(DateTime criadoEm)
        {
            if(criadoEm < DateTime.MinValue || criadoEm > DateTime.MaxValue)
                throw new Exception("Data inválida");

            CriadoEm = criadoEm;
        }

    }
}