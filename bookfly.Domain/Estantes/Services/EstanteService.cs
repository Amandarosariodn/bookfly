using bookfly.Domain.Estantes.Commands;
using bookfly.Domain.Estantes.Entities;
using bookfly.Domain.Estantes.Repositories.Filters;
using bookfly.Domain.Estantes.Repositories.Interfaces;
using bookfly.Domain.Estantes.Services.Interfaces;

namespace bookfly.Domain.Estantes.Services
{
    public class EstanteService(IEstanteRepository estanteRepository) : IEstantesService
    {
        public async Task<Estante> InserirEstanteAsync(InserirEstanteCommand comando, CancellationToken cancellationToken)
        {
            Estante estante = Instanciar(comando);
            await estanteRepository.InserirAsync(estante, cancellationToken);
            return estante;
        }

        public async Task<Estante> EditarEstanteAsync(EditarEstanteCommand comando, int id, CancellationToken cancellationToken)
        {
            Estante estante = await ValidarAsync(id, cancellationToken);

            estante.SetUsuarioId(comando.UsuarioId);
            estante.SetNome(comando.Nome);
            estante.SetDescricao(comando.Descricao);
            estante.SetPrivada(comando.Privada);

            await estanteRepository.EditarAsync(estante, cancellationToken);
            return estante;
        }

        public Estante Instanciar(InserirEstanteCommand comando)
        {
            return new Estante(
                usuarioId: comando.UsuarioId,
                nome: comando.Nome,
                descricao: comando.Descricao,
                privada: comando.Privada,
                criadoEm: DateTime.Now
            );
        }

        public async Task<List<Estante>> ListarAsync(EstanteFiltro categoria, CancellationToken cancellationToken)
        {
            var estantes = await estanteRepository.ListarAsync(categoria, cancellationToken);

            if (estantes == null || !estantes.Any())
                return new List<Estante>();

            return estantes;
        }

        public async Task MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            Estante estante = await ValidarAsync(id, cancellationToken);
            estante.SetPrivada(!estante.Privada);
            await estanteRepository.EditarAsync(estante, cancellationToken);
        }

        public async Task<Estante> ValidarAsync(int id, CancellationToken cancellationToken)
        {
            Estante? estante = await estanteRepository.RecuperarPorIdAsync(id, cancellationToken);

            if (estante is null)
                throw new Exception("Estante não encontrada");

            return estante;
        }
    }
}
