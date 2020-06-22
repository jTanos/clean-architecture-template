namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Update
{
    public class UpdateEntityUseCaseRequest<T> : IUseCaseRequest
    {
        public T Entity { get; }

        public UpdateEntityUseCaseRequest(T entity)
        {
            Entity = entity;
        }
    }
}
