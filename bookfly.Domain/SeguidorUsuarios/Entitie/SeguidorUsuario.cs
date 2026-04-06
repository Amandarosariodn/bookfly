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
    }
}