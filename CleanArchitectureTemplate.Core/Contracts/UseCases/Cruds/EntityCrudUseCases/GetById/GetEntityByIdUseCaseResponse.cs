using CleanArchitectureTemplate.Core.Contracts.Entities;

namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.GetById
{
    public class GetEntityByIdUseCaseResponse<T> : IUseCaseResponse where T : class, IEntity
    {
        public T Entity { get; }

        public GetEntityByIdUseCaseResponse(T entity)
        {
            Entity = entity;
        }
    }
}
