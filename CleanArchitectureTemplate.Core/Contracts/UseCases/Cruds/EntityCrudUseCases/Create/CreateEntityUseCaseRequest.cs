namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Create
{
    public class CreateEntityUseCaseRequest<T> : IUseCaseRequest
    {
        public T Entity { get; }

        public CreateEntityUseCaseRequest(T entity)
        {
            Entity = entity;
        }
    }
}
