

namespace bookfly.Domain.Usuarios.Entities
{
    public class Usuario
    {
        public virtual int Id { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Username { get; protected set; }
        public virtual string SenhaHash { get; protected set; }
        public virtual string Biografia { get; protected set; }
        public virtual string UrlImagem { get; protected set; }
        public virtual bool ReceberSpoilers { get; protected set; }
        public virtual bool Situacao { get; protected set; }
        public virtual DateTime CriadoEm { get; protected set; }

        protected Usuario()
        {
        }

        public Usuario(string email, string username, string senhaHash)
        {
            SetEmail(email);
            SetUsername(username);
            SetSenhaHash(senhaHash);
            CriadoEm = DateTime.Now;
            Ativar();

        }

        public virtual void SetEmail(string email)
        {
            if(email.Length < 7)
                throw new ArgumentException("O email deve conter pelo menos 7 caracteres.");
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("O email não pode ser vazio.");
            if(!email.Contains("@"))
                throw new ArgumentException("O email deve ser válido.");
            Email = email;
        }

        public virtual void SetUsername(string username)
        {
        if (username.Length < 3)
                throw new ArgumentException("O nome de usuário deve conter pelo menos 3 caracteres.");
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("O nome de usuário não pode ser vazio.");
            Username = username;
        }

        public virtual void SetSenhaHash(string senhaHash)
        {
            if (string.IsNullOrEmpty(senhaHash))
                throw new ArgumentException("A senha não pode ser vazia.");
            SenhaHash = senhaHash;
        }

        public virtual void SetBiografia(string biografia)
        {
            Biografia = biografia;
        }

        public virtual void SetUrlImagem(string urlImagem)
        {
            UrlImagem = urlImagem;
        }

        public virtual void SetReceberSpoilers(bool receberSpoilers)
        {
            ReceberSpoilers = receberSpoilers;
        }

        public virtual void SetSituacao(bool situacao)
        {
            Situacao = situacao;
        }

        public virtual void SetCriadoEm(DateTime criadoEm)
        {
            if (criadoEm > DateTime.UtcNow)
                throw new ArgumentException("A data de criação deve ser válida.");
            CriadoEm = criadoEm;
        }

        public virtual void Ativar()
        {
            Situacao = true;
        }

    }
}