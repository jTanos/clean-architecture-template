namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Update
{
    public class UpdateEntityUseCaseResponse : IUseCaseResponse
    {
        public long Id { get; }

        public UpdateEntityUseCaseResponse(long id)
        {
            Id = id;
        }
    }
}
