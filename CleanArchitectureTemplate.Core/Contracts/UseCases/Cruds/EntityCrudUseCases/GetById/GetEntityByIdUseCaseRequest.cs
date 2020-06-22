namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.GetById
{
    public class GetEntityByIdUseCaseRequest : IUseCaseRequest
    {
        public long Id { get; }

        public GetEntityByIdUseCaseRequest(long id)
        {
            Id = id;
        }
    }
}
