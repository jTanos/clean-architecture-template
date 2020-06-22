using CleanArchitectureTemplate.Core.Contracts.Entities;

namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Update
{
    public interface IUpdateEntityUseCase<T> : IUseCase<UpdateEntityUseCaseRequest<T>, UpdateEntityUseCaseResponse> where T : class, IEntity
    {
    }
}
