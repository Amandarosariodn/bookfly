using bookfly.Domain.MembrosComunidade.Commands;
using bookfly.Domain.MembrosComunidade.Entities;
using bookfly.Domain.MembrosComunidade.Repositories;
using bookfly.Domain.MembrosComunidade.Repositories.Filters;
using bookfly.Domain.MembrosComunidade.Services.Interfaces;

namespace bookfly.Domain.MembrosComunidade.Services
{
    public class MembrosComunidadeService(IMembrosComunidadeRepository membrosComunidadeRepository) : IMembrosComunidadeService
    {
        public async Task<MembroComunidade> EditarMembroComunidadeAsync(EditarMembroComunidadeCommand comando, int id, CancellationToken cancellationToken)
        {
            MembroComunidade cargoComunidade = await ValidarAsync(id, cancellationToken);

            cargoComunidade.SetCargoId(comando.CargoId);
            cargoComunidade.SetBanido(comando.Banido);

            await membrosComunidadeRepository.EditarAsync(cargoComunidade, cancellationToken);
            return cargoComunidade;
        }

        public async Task<MembroComunidade> InserirMembroComunidadeAsync(InserirMembroComunidadeCommand comando, CancellationToken cancellationToken)
        {
            MembroComunidade membroComunidade = Instanciar(comando);
            await membrosComunidadeRepository.InserirAsync(membroComunidade, cancellationToken);
            return membroComunidade;
        }

        public MembroComunidade Instanciar(InserirMembroComunidadeCommand comando)
        {
            return new MembroComunidade(
                comunidadeId: comando.ComunidadeId,
                usuarioId: comando.UsuarioId,
                cargoId: comando.CargoId,
                banido: comando.Banido)
                ;
        }

        public async Task<List<MembroComunidade>> ListarAsync(MembroComunidadeFiltro filtro, CancellationToken cancellationToken)
        {
              List<MembroComunidade> membroComunidades = await membrosComunidadeRepository.ListarAsync(filtro, cancellationToken);
            return membroComunidades ?? new List<MembroComunidade>();
        }

        public async Task<MembroComunidade> ValidarAsync(int id, CancellationToken cancellationToken)
        {
           MembroComunidade? membroComunidade = await membrosComunidadeRepository.RecuperarPorIdAsync(id, cancellationToken);

            if (membroComunidade is null)
                throw new Exception("Cargo de comunidade não encontrado");

            return membroComunidade;
        }
    }
}