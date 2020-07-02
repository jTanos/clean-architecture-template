using CleanArchitectureTemplate.Core.Contracts.Logger;
using CleanArchitectureTemplate.Core.Contracts.Repositories;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.GetById;
using CleanArchitectureTemplate.Core.Entities;
using CleanArchitectureTemplate.Core.UseCases.Cruds.EntityCrudUseCases;

namespace CleanArchitectureTemplate.Core.UseCases.Cruds.FooCrudUseCases
{
    public class GetFooByIdUseCase : GetEntityByIdUseCase<Foo>, IGetFooByIdUseCase
    {
        public GetFooByIdUseCase(IFooRepository fooRepository, ICoreLogger coreLogger) : base(fooRepository, coreLogger)
        {
        }
    }
}