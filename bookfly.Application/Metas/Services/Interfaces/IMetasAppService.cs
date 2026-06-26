using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Application.Metas.DataTransfer.Requests;
using bookfly.Application.Metas.DataTransfer.Responses;

namespace bookfly.Application.Metas.Services.Interfaces
{
    public interface IMetasAppService
    {
        Task<MetaResponse> EditarAsync(int id, EditarMetaRequest request, CancellationToken cancellationToken);
        Task<MetaResponse> RecuperarAsync(int id, CancellationToken cancellationToken);
        Task<MetaResponse> InserirAsync(InserirMetaRequest request, string token, CancellationToken cancellationToken);

    }
}