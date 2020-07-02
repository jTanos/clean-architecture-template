using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Core.Contracts.Entities;
using CleanArchitectureTemplate.Core.Contracts.Logger;
using CleanArchitectureTemplate.Core.Contracts.Repositories;
using CleanArchitectureTemplate.Core.Contracts.UseCases;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.GetAll;

namespace CleanArchitectureTemplate.Core.UseCases.Cruds.EntityCrudUseCases
{
    public class GetAllEntitysUseCase<T> : IGetAllEntitysUseCase<T> where T : class, IEntity
    {
        protected readonly IRepository<T> Repository;
        protected readonly ICoreLogger CoreLogger;

        protected GetAllEntitysUseCase(IRepository<T> repository, ICoreLogger coreLogger)
        {
            Repository = repository;
            CoreLogger = coreLogger;
        }

        public virtual void Execute(GetAllEntitysUseCaseRequest useCaseRequest, IOutputPort<GetAllEntityUseCaseResponse<T>> outputPort)
        {
            IEnumerable<T> entities;

            try
            {
                entities = Repository.GetAll();
            }
            catch (Exception exception)
            {
                CoreLogger.LogError(exception);

                outputPort.HandleError(new SimpleUseCaseError(1, "Unknown Error"));
                return;
            }

            var getAllEntityUseCaseResponse = new GetAllEntityUseCaseResponse<T>(entities);

            outputPort.HandleSuccess(getAllEntityUseCaseResponse);
        }

        public virtual async Task ExecuteAsync(GetAllEntitysUseCaseRequest useCaseRequest, IOutputPort<GetAllEntityUseCaseResponse<T>> outputPort)
        {
            IEnumerable<T> entities;

            try
            {
                entities = await Repository.GetAllAsync();
            }
            catch (Exception exception)
            {
                CoreLogger.LogError(exception);

                outputPort.HandleError(new SimpleUseCaseError(1, "Unknown Error"));
                return;
            }

            var getAllEntityUseCaseResponse = new GetAllEntityUseCaseResponse<T>(entities);

            outputPort.HandleSuccess(getAllEntityUseCaseResponse);
        }
    }
}
