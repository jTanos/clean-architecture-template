using CleanArchitectureTemplate.Core.Contracts.Entities;

namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Create
{
    public interface ICreateEntityUseCase<T> : IUseCase<CreateEntityUseCaseRequest<T>, CreateEntityUseCaseResponse> where T : class, IEntity
    {
    }
}
