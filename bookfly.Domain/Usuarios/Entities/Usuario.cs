
using bookfly.Domain.Enums;

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
        public virtual AtivoInativoEnum Situacao { get; protected set; }
        public virtual DateTime CriadoEm { get; protected set; }

        public Usuario()
        {
        }

        public Usuario(string email, string username, string senhaHash, string biografia, string urlImagem, bool receberSpoilers, DateTime criadoEm)
        {
            SetEmail(email);
            SetUsername(username);
            SetSenhaHash(senhaHash);
            SetBiografia(biografia);
            SetUrlImagem(urlImagem);
            SetReceberSpoilers(receberSpoilers);
            SetCriadoEm(criadoEm);
            Ativar();
           
        }

        public virtual void SetEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("O email não pode ser vazio.");
            Email = email;
        }

        public virtual void SetUsername(string username)
        {
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
            if (string.IsNullOrEmpty(biografia))
                throw new ArgumentException("A biografia não pode ser vazia.");
            Biografia = biografia;
        }

        public virtual void SetUrlImagem(string urlImagem)
        {
            if (string.IsNullOrEmpty(urlImagem))
                throw new ArgumentException("A URL da imagem não pode ser vazia.");
            UrlImagem = urlImagem;
        }

        public virtual void SetReceberSpoilers(bool receberSpoilers)
        {
            ReceberSpoilers = receberSpoilers;
        }

        public virtual void SetSituacao(AtivoInativoEnum situacao)
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
            Situacao = AtivoInativoEnum.Ativo;
        }

    }
}