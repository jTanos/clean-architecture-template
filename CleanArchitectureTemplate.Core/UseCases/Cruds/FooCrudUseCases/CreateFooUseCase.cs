using CleanArchitectureTemplate.Core.Contracts.EntitiesValidators;
using CleanArchitectureTemplate.Core.Contracts.Log;
using CleanArchitectureTemplate.Core.Contracts.Repositories;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.Create;
using CleanArchitectureTemplate.Core.Entities;
using CleanArchitectureTemplate.Core.UseCases.Cruds.EntityCrudUseCases;

namespace CleanArchitectureTemplate.Core.UseCases.Cruds.FooCrudUseCases
{
    public class CreateFooUseCase : CreateEntityUseCase<Foo>, ICreateFooUseCase
    {
        public CreateFooUseCase(IFooRepository fooRepository, IFooValidator fooValidator, ICoreLogger coreLogger) : base(fooRepository, fooValidator, coreLogger)
        {
        }
    }
}
