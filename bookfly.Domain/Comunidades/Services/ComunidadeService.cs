using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Domain.Comunidades.Commands;
using bookfly.Domain.Comunidades.Entities;
using bookfly.Domain.Comunidades.Repositories.Filters;
using bookfly.Domain.Comunidades.Repositories.Interfaces;
using bookfly.Domain.Comunidades.Services.Interfaces;

namespace bookfly.Domain.Comunidades.Services
{
    public class ComunidadeService(IComunidadeRepository comunidadeRepository) : IComunidadeService
    {
        public async Task<Comunidade> EditarComunidadeAsync(ComunidadeEditarCommand comando, int id, CancellationToken cancellationToken)
        {
            Comunidade comunidade = await ValidarAsync(id, cancellationToken);

            comunidade.SetNome(comando.Nome);
            comunidade.SetDescricao(comando.Descricao);
            comunidade.SetUrlImagem(comando.UrlImagem);
            comunidade.SetAtivo(comando.Ativo);
            comunidade.SetPrivado(comando.Privado);

            await comunidadeRepository.EditarAsync(comunidade, cancellationToken);
            return comunidade;
        }

        public async Task<Comunidade> InserirComunidadeAsync(ComunidadeInserirCommand comando, CancellationToken cancellationToken)
        {
            Comunidade comunidade = Instanciar(comando);
            await comunidadeRepository.InserirAsync(comunidade, cancellationToken);
            return comunidade;
        }

        public Comunidade Instanciar(ComunidadeInserirCommand comando)
        {
            return new Comunidade(
                criadorId: comando.CriadorId,
                nome: comando.Nome,
                descricao: comando.Descricao,
                urlImagem: comando.UrlImagem,
                privado: comando.Privado
            );
        }

        public async Task<List<Comunidade>> ListarAsync(ComunidadeFiltro filtro, CancellationToken cancellationToken)
        {
            var comunidades = await comunidadeRepository.ListarAsync(filtro, cancellationToken);

            if (comunidades == null || !comunidades.Any())
                return new List<Comunidade>();

            return comunidades;
        }

        public async Task MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            Comunidade comunidade = await ValidarAsync(id, cancellationToken);
            comunidade.SetAtivo(!comunidade.Ativo);
            await comunidadeRepository.EditarAsync(comunidade, cancellationToken);
        }

        public async Task<Comunidade> ValidarAsync(int id, CancellationToken cancellationToken)
        {
            Comunidade? comunidade = await comunidadeRepository.RecuperarPorIdAsync(id, cancellationToken);

            if (comunidade is null)
                throw new Exception("Comunidade não encontrada");

            return comunidade;
        }
    }
}