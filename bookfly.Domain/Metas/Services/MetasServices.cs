using bookfly.Domain.Metas.Commands;
using bookfly.Domain.Metas.Entities;
using bookfly.Domain.Metas.Repositories;
using bookfly.Domain.Metas.Services.Interfaces;

namespace bookfly.Domain.Metas.Services
{
    public class MetasServices(IMetaRepository metasRepository) : IMetasServices
    {
        public async Task<Meta> EditarMetaAsync(EditarMetaCommand comando, int id, CancellationToken cancellationToken)
        {
            Meta meta = await ValidarAsync(id, cancellationToken);

            meta.SetNome(comando.Nome);
            meta.SetDescricao(comando.Descricao);
            meta.SetQuantidadeMeta(comando.QuantidadeMeta);
            meta.SetQuantidadeAtual(comando.QuantidadeAtual);
            meta.SetAno(comando.Ano);

            await metasRepository.EditarAsync(meta, cancellationToken);
            return meta;
        }

        public async Task<Meta> InserirMetaAsync(InserirMetaCommand comando, CancellationToken cancellationToken)
        {

            Meta meta = Instanciar(comando);
            if (await metasRepository.ExisteMeta(comando.UsuarioId, cancellationToken) != null)
                throw new Exception("Meta já cadastrada para este usuário");

            await metasRepository.InserirAsync(meta, cancellationToken);
            return meta;
        }

        public Meta Instanciar(InserirMetaCommand comando)
        {
            return new Meta(
                usuarioId: comando.UsuarioId,
                nome: comando.Nome,
                descricao: comando.Descricao,
                quantidadeMeta: comando.QuantidadeMeta,
                quantidadeAtual: comando.QuantidadeAtual,
                ano: comando.Ano            );
        }


        public async Task<Meta> ValidarAsync(int MetaId, CancellationToken cancellationToken)
        {

            Meta? meta = await metasRepository.RecuperarPorIdAsync(MetaId, cancellationToken);

            if (meta == null)
                throw new Exception("Meta não encontrada");

            return meta;
        }
    }
}