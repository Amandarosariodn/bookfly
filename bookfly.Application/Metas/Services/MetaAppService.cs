using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Application.Metas.DataTransfer.Requests;
using bookfly.Application.Metas.DataTransfer.Responses;
using bookfly.Application.Metas.Services.Interfaces;
using bookfly.Application.Shared.UnitOfWork;
using bookfly.Application.Usuarios.DataTransfer.Responses;
using bookfly.Application.Usuarios.Services.Interfaces;
using bookfly.Domain.Metas.Commands;
using bookfly.Domain.Metas.Entities;
using bookfly.Domain.Metas.Services.Interfaces;
using Mapster;

namespace bookfly.Application.Metas.Services
{
    public class MetaAppService(IUnitOfWork unitOfWork, IMetasServices metaService, IUsuariosAppService usuariosAppService) : IMetasAppService
    {
        public async Task<MetaResponse> EditarAsync(int id, EditarMetaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<EditarMetaCommand>();
                Meta meta = await metaService.ValidarAsync(id, cancellationToken);
                await unitOfWork.BeginAsync(cancellationToken);
                await metaService.EditarMetaAsync(command, id, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return meta.Adapt<MetaResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<MetaResponse> InserirAsync(InserirMetaRequest request, string token, CancellationToken cancellationToken)
        {
            UsuarioResponse usuarioLogado = await usuariosAppService.RecuperarUsuarioLogadoAsync(token, cancellationToken);

            var command = request.Adapt<InserirMetaCommand>();

            command.UsuarioId = usuarioLogado.Id;
            await unitOfWork.BeginAsync(cancellationToken);
            try
            {
                Meta meta = await metaService.InserirMetaAsync(command, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return meta.Adapt<MetaResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<MetaResponse> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            Meta meta = await metaService.ValidarAsync(id, cancellationToken);
            return meta.Adapt<MetaResponse>();
        }
    }
}