namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Delete
{
    public class DeleteEntityUseCaseResponse : IUseCaseResponse
    {
        public long Id { get; }

        public DeleteEntityUseCaseResponse(long id)
        {
            Id = id;
        }
    }
}
