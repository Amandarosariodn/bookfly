
namespace bookfly.Domain.MembrosComunidade.Entities
{
    public class MembroComunidade
    {
        public virtual int Id { get; protected set; }
        public virtual int ComunidadeId { get; protected set; }
        public virtual int UsuarioId { get; protected set; }
        public virtual int CargoId { get; protected set; }
        public virtual bool Banido { get; protected set; }
        public virtual DateTime EntrouEm { get; protected set; }

        protected MembroComunidade() { }

        public MembroComunidade(int comunidadeId, int usuarioId, int cargoId, bool banido, DateTime entrouEm)
        {
            SetComunidadeId(comunidadeId);
            SetUsuarioId(usuarioId);
            SetCargoId(cargoId);
            SetBanido(banido);
            SetEntrouEm(entrouEm);
        }

        public virtual void SetComunidadeId(int comunidadeId)
        {
            if (comunidadeId < 0)
                throw new ArgumentException("Comunidade Inválida");

            ComunidadeId = comunidadeId;
        }

        public virtual void SetUsuarioId(int usuarioId)
        {
            if (usuarioId < 0)
                throw new ArgumentException("O id do usuário não pode ser menor que zero");

            UsuarioId = usuarioId;
        }

        public virtual void SetCargoId(int cargoId)
        {
            if (cargoId < 0)
                throw new ArgumentException("Id do cargo nao pode ser menor que zero");

            CargoId = cargoId;
        }

        public virtual void SetBanido(bool banido)
        {
            Banido = banido;
        }

        public virtual void SetEntrouEm(DateTime entrouEm)
        {
            entrouEm = DateTime.Now;

            EntrouEm = entrouEm;
        }

        public virtual void Banir()
        {
            SetBanido(true);
        }
    }
}