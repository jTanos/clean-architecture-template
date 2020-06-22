namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.GetByName
{
    public class GetFooByNameUseCaseRequest : IUseCaseRequest
    {
        public GetFooByNameUseCaseRequest(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
