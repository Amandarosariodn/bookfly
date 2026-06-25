

using bookfly.Domain.Metas.Commands;
using bookfly.Domain.Metas.Entities;

namespace bookfly.Domain.Metas.Services.Interfaces
{
    public interface IMetasServices
    {
            
        Task<Meta> ValidarAsync(int MetaId, CancellationToken cancellationToken);
        Task<Meta> InserirMetaAsync(InserirMetaCommand comando, CancellationToken cancellationToken);
        Task<Meta> EditarMetaAsync(EditarMetaCommand comando, int id, CancellationToken cancellationToken);
        Meta Instanciar(InserirMetaCommand comando);
    }
}