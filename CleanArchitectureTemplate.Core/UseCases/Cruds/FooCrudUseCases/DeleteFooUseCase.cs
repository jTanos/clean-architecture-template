using CleanArchitectureTemplate.Core.Contracts.Logger;
using CleanArchitectureTemplate.Core.Contracts.Repositories;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.Delete;
using CleanArchitectureTemplate.Core.Entities;
using CleanArchitectureTemplate.Core.UseCases.Cruds.EntityCrudUseCases;

namespace CleanArchitectureTemplate.Core.UseCases.Cruds.FooCrudUseCases
{
    public class DeleteFooUseCase : DeleteEntityUseCase<Foo>, IDeleteFooUseCase
    {
        public DeleteFooUseCase(IFooRepository fooRepository, ICoreLogger coreLogger) : base(fooRepository, coreLogger)
        {
        }
    }
}
