namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Delete
{
    public class DeleteEntityUseCaseRequest : IUseCaseRequest
    {
        public long Id { get; }

        public DeleteEntityUseCaseRequest(long id)
        {
            Id = id;
        }
    }
}
