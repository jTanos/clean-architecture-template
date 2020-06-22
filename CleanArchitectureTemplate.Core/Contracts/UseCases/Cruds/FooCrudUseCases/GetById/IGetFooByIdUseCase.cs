using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.GetById;
using CleanArchitectureTemplate.Core.Entities;

namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.GetById
{
    public interface IGetFooByIdUseCase : IGetEntityByIdUseCase<Foo>
    {
    }
}
