using CleanArchitectureTemplate.Core.Contracts.Entities;

namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.GetById
{
    public interface IGetEntityByIdUseCase<T> : IUseCase<GetEntityByIdUseCaseRequest, GetEntityByIdUseCaseResponse<T>> where T : class, IEntity
    {
    }
}
