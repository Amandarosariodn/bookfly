using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using bookfly.Domain.CargosComunidade.Commands;
using bookfly.Domain.CargosComunidade.Entities;
using bookfly.Domain.CargosComunidade.Repositories.Filters;
using bookfly.Domain.CargosComunidade.Repositories.Interfaces;
using bookfly.Domain.CargosComunidade.Services.Interfaces;

namespace bookfly.Domain.CargosComunidade.Services
{
    public class CargoComunidadeService(ICargoComunidadeRepository cargoComunidadeRepository) : ICargoComunidadeService
    {
        public async Task<CargoComunidade> InserirCargoComunidadeAsync(InserirCargoComunidadeCommand comando, CancellationToken cancellationToken)
        {
            CargoComunidade cargoComunidade = Instanciar(comando);
            await cargoComunidadeRepository.InserirAsync(cargoComunidade, cancellationToken);
            return cargoComunidade;
        }

        public async Task<CargoComunidade> EditarCargoComunidadeAsync(EditarCargoComunidadeCommand comando, int id, CancellationToken cancellationToken)
        {
            CargoComunidade cargoComunidade = await ValidarAsync(id, cancellationToken);

            cargoComunidade.SetComunidadeId(comando.ComunidadeId);
            cargoComunidade.SetNome(comando.Nome);
            cargoComunidade.SetPodeDeletar(comando.PodeDeletar);
            cargoComunidade.SetPodeBanir(comando.PodeBanir);
            cargoComunidade.SetPodeFixarPost(comando.PodeFixarPost);

            await cargoComunidadeRepository.EditarAsync(cargoComunidade, cancellationToken);
            return cargoComunidade;
        }

        public CargoComunidade Instanciar(InserirCargoComunidadeCommand comando)
        {
            return new CargoComunidade(
                comunidadeId: comando.ComunidadeId,
                nome: comando.Nome,
                podeDeletar: comando.PodeDeletar,
                podeBanir: comando.PodeBanir,
                podeFixarPost: comando.PodeFixarPost);
        }

        public async Task<List<CargoComunidade>> ListarAsync(CargoComunidadeFiltro filtro, CancellationToken cancellationToken)
        {
            List<CargoComunidade> cargosComunidade = await cargoComunidadeRepository.ListarAsync(filtro, cancellationToken);
            return cargosComunidade ?? new List<CargoComunidade>();
        }

        public async Task<CargoComunidade> ValidarAsync(int id, CancellationToken cancellationToken)
        {
            CargoComunidade? cargoComunidade = await cargoComunidadeRepository.RecuperarPorIdAsync(id, cancellationToken);

            if (cargoComunidade is null)
                throw new Exception("Cargo de comunidade não encontrado");

            return cargoComunidade;
        }
    }
}