using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Create;
using CleanArchitectureTemplate.Core.Entities;

namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.Create
{
    public interface ICreateFooUseCase : ICreateEntityUseCase<Foo>
    {
    }
}
