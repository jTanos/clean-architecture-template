using CleanArchitectureTemplate.Core.Contracts.Entities;

namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Delete
{
    public interface IDeleteEntityUseCase<T> : IUseCase<DeleteEntityUseCaseRequest, DeleteEntityUseCaseResponse> where T : class, IEntity
    {
    }
}
