using CleanArchitectureTemplate.Core.Contracts.Logger;
using CleanArchitectureTemplate.Core.Contracts.Repositories;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.GetAll;
using CleanArchitectureTemplate.Core.Entities;
using CleanArchitectureTemplate.Core.UseCases.Cruds.EntityCrudUseCases;

namespace CleanArchitectureTemplate.Core.UseCases.Cruds.FooCrudUseCases
{
    public class GetAllFoosUseCase : GetAllEntitysUseCase<Foo>, IGetAllFoosUseCase
    {
        public GetAllFoosUseCase(IFooRepository fooRepository, ICoreLogger coreLogger) : base(fooRepository, coreLogger)
        {
        }
    }
}
