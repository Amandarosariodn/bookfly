using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Domain.Metas.Entities;

namespace bookfly.Domain.Metas.Repositories
{
    public interface IMetaRepository
    {
        Task InserirAsync(Meta meta, CancellationToken cancellationToken);
        Task EditarAsync(Meta meta, CancellationToken cancellationToken);
        Task<Meta> ValidarAsync(int metaId, CancellationToken cancellationToken);
        Task<Meta?> RecuperarPorIdAsync(int id, CancellationToken cancellationToken);

        Task<Meta?> ExisteMeta(int usuarioId, CancellationToken cancellationToken);
    }
}