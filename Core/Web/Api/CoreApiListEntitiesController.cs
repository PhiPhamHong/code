using System.Collections.Generic;
using Core.Attributes;
using Core.DataBase.ADOProvider;
namespace Core.Web.Api
{
    public abstract class CoreApiListEntitiesController<TRequest, TResponse, TEntity> : CoreApiController<TRequest, TResponse>
        where TRequest : CoreApiListEntitiesController<TRequest, TResponse, TEntity>.ClientRequest, new()
        where TResponse : CoreApiListEntitiesController<TRequest, TResponse, TEntity>.Response, new()
        where TEntity : ModelBase<TEntity>, new()
    {
        public class ClientRequest
        {

        }

        public class Response : ResponseBase
        {
            [PropertyIndex(Index = 0)]
            public virtual List<TEntity> Data { set; get; }
        }

        sealed protected override void FillResponse(TRequest request, TResponse response)
        {   
            response.Data = ModelBase<TEntity>.Inst.GetAllToList();
        }
    }

    public abstract class CoreApiListEntitiesController<TEntity> : CoreApiListEntitiesController<CoreApiListEntitiesController<TEntity>.ClientConcreteRequest, CoreApiListEntitiesController<TEntity>.ServerResponse, TEntity>
        where TEntity : ModelBase<TEntity>, new()
    {
        public class ClientConcreteRequest : ClientRequest
        {

        }

        public class ServerResponse : Response
        {
            
        }
    }
}