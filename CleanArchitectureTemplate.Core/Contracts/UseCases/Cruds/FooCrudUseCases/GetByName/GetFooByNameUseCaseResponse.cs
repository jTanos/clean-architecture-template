using CleanArchitectureTemplate.Core.Entities;

namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.GetByName
{
    public class GetFooByNameUseCaseResponse : IUseCaseResponse
    {
        public GetFooByNameUseCaseResponse(Foo foo)
        {
            Foo = foo;
        }

        public Foo Foo { get; }
    }
}
