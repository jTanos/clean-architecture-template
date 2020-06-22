namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Create
{
    public class CreateEntityUseCaseResponse : IUseCaseResponse
    {
        public long Id { get; }

        public CreateEntityUseCaseResponse(long id)
        {
            Id = id;
        }
    }
}
