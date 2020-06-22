using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Delete;
using CleanArchitectureTemplate.Core.Entities;

namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.Delete
{
    public interface IDeleteFooUseCase : IDeleteEntityUseCase<Foo>
    {
    }
}
