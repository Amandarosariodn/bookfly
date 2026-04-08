namespace bookfly.Domain.SeguidorUsuarios.Entities
{
    public class SeguidorUsuario
    {
        public virtual int SeguidorID { get; protected set; }
        public virtual int SeguidoID { get; protected set; }
        public virtual DateTime CriadoEm { get; protected set; }

        protected SeguidorUsuario() { }

        public SeguidorUsuario(int seguidorId, int seguidoId)
        {
            if (seguidorId == seguidoId)
                throw new ArgumentException("Usuário não pode seguir a si mesmo.");

            SeguidorID = seguidorId;
            SeguidoID = seguidoId;
            CriadoEm = DateTime.UtcNow;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (SeguidorUsuario)obj;

            return SeguidorID == other.SeguidorID
                && SeguidoID == other.SeguidoID;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + SeguidorID.GetHashCode();
                hash = hash * 23 + SeguidoID.GetHashCode();
                return hash;
            }
        }
    }
}