using bookfly.Domain.Usuarios.Entities;
using bookfly.Domain.Usuarios.Repositories;
using bookfly.Domain.Usuarios.Repositories.Filters;
using NHibernate;
using NHibernate.Linq;


namespace bookfly.Infra.Usuarios.Repositories
{
    public class UsuarioRepository(ISession session) : IUsuariosRepository
    {
        private readonly ISession _session = session;

        public async Task EditarAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            await _session.UpdateAsync(usuario, cancellationToken);
        }

        public async Task InserirAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            await _session.SaveAsync(usuario, cancellationToken);
        }

        public async Task<List<Usuario>> ListarAsync(UsuarioFiltro filtro, CancellationToken cancellationToken)
        {
            var query = _session.Query<Usuario>();

            if (!string.IsNullOrEmpty(filtro.Username))
                query = query.Where(l => l.Username.Contains(filtro.Username));

            return await query.ToListAsync(cancellationToken);
        }


        public async Task<Usuario> ValidarAsync(int usuarioId, CancellationToken cancellationToken)
        {
            var query = _session.Query<Usuario>();

            var usuario = await query
                .Where(u => u.Id == usuarioId)
                .FirstOrDefaultAsync(cancellationToken);

            return usuario;
        }
    }
}