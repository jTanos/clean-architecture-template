using CleanArchitectureTemplate.Core.Contracts.Entities;

namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.GetAll
{
    public interface IGetAllEntitysUseCase<T> : IUseCase<GetAllEntitysUseCaseRequest, GetAllEntityUseCaseResponse<T>> where T : class, IEntity
    {

    }
}
