using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.GetAll;
using CleanArchitectureTemplate.Core.Entities;

namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.GetAll
{
    public interface IGetAllFoosOutputPort : IOutputPort<GetAllEntityUseCaseResponse<Foo>>
    {
    }
}
