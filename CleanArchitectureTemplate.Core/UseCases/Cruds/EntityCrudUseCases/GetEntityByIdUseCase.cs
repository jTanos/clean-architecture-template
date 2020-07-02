using System;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Core.Contracts.Entities;
using CleanArchitectureTemplate.Core.Contracts.Logger;
using CleanArchitectureTemplate.Core.Contracts.Repositories;
using CleanArchitectureTemplate.Core.Contracts.UseCases;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.GetById;

namespace CleanArchitectureTemplate.Core.UseCases.Cruds.EntityCrudUseCases
{
    public class GetEntityByIdUseCase<T> : IGetEntityByIdUseCase<T> where T : class, IEntity
    {
        protected readonly IRepository<T> Repository;
        protected readonly ICoreLogger CoreLogger;

        protected GetEntityByIdUseCase(IRepository<T> repository, ICoreLogger coreLogger)
        {
            Repository = repository;
            CoreLogger = coreLogger;
        }

        public virtual void Execute(GetEntityByIdUseCaseRequest useCaseRequest, IOutputPort<GetEntityByIdUseCaseResponse<T>> outputPort)
        {
            T entity;

            try
            {
                entity = Repository.GetById(useCaseRequest.Id);
            }
            catch (Exception exception)
            {
                CoreLogger.LogError(exception);

                outputPort.HandleError(new SimpleUseCaseError(2, "Unknown Error"));
                return;
            }

            if (entity == default(T))
            {
                outputPort.HandleError(new SimpleUseCaseError(1, $"{typeof(T).Name} with {nameof(useCaseRequest.Id)} {useCaseRequest.Id} not exists"));
                return;
            }

            var getByIdEntityUseCaseResponse = new GetEntityByIdUseCaseResponse<T>(entity);

            outputPort.HandleSuccess(getByIdEntityUseCaseResponse);
        }

        public virtual async Task ExecuteAsync(GetEntityByIdUseCaseRequest useCaseRequest, IOutputPort<GetEntityByIdUseCaseResponse<T>> outputPort)
        {
            T entity;

            try
            {
                entity = await Repository.GetByIdAsync(useCaseRequest.Id);
            }
            catch (Exception exception)
            {
                CoreLogger.LogError(exception);

                outputPort.HandleError(new SimpleUseCaseError(2, "Unknown Error"));
                return;
            }

            if (entity == default(T))
            {
                outputPort.HandleError(new SimpleUseCaseError(1, $"{typeof(T).Name} with {nameof(useCaseRequest.Id)} {useCaseRequest.Id} not exists"));
                return;
            }

            var getByIdEntityUseCaseResponse = new GetEntityByIdUseCaseResponse<T>(entity);

            outputPort.HandleSuccess(getByIdEntityUseCaseResponse);
        }
    }
}