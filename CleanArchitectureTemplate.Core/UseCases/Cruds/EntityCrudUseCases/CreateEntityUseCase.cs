using System;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Core.Contracts.Entities;
using CleanArchitectureTemplate.Core.Contracts.EntitiesValidators;
using CleanArchitectureTemplate.Core.Contracts.Log;
using CleanArchitectureTemplate.Core.Contracts.Repositories;
using CleanArchitectureTemplate.Core.Contracts.UseCases;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Create;

namespace CleanArchitectureTemplate.Core.UseCases.Cruds.EntityCrudUseCases
{
    public class CreateEntityUseCase<T> : ICreateEntityUseCase<T> where T : class, IEntity
    {
        protected readonly IRepository<T> Repository;
        protected readonly IEntityValidator<T> EntityValidator;
        protected readonly ICoreLogger CoreLogger;

        protected CreateEntityUseCase(IRepository<T> repository, IEntityValidator<T> entityValidator, ICoreLogger coreLogger)
        {
            Repository = repository;
            EntityValidator = entityValidator;
            CoreLogger = coreLogger;
        }

        public virtual void Execute(CreateEntityUseCaseRequest<T> useCaseRequest, IOutputPort<CreateEntityUseCaseResponse> outputPort)
        {
            if (!EntityValidator.IsValid(useCaseRequest.Entity))
            {
                outputPort.HandleError(new SimpleUseCaseError(1, "Not Valid Entity"));
                return;
            }

            long id;

            try
            {
                id = Repository.Add(useCaseRequest.Entity);
            }
            catch (Exception exception)
            {
                CoreLogger.LogError(exception);

                outputPort.HandleError(new SimpleUseCaseError(2, "Add Not Found"));
                return;
            }

            if (id == default(long))
            {
                outputPort.HandleError(new SimpleUseCaseError(2, "Add Not Found"));
                return;
            }

            var createEntityUseCaseResponse = new CreateEntityUseCaseResponse(id);

            outputPort.HandleSuccess(createEntityUseCaseResponse);
        }

        public virtual async Task ExecuteAsync(CreateEntityUseCaseRequest<T> useCaseRequest, IOutputPort<CreateEntityUseCaseResponse> outputPort)
        {
            if (!EntityValidator.IsValid(useCaseRequest.Entity))
            {
                outputPort.HandleError(new SimpleUseCaseError(1, "Not Valid Entity"));
                return;
            }

            long id;

            try
            {
                id = await Repository.AddAsync(useCaseRequest.Entity);
            }
            catch (Exception exception)
            {
                CoreLogger.LogError(exception);

                outputPort.HandleError(new SimpleUseCaseError(2, "Add Not Found"));
                return;
            }

            if (id == default(long))
            {
                outputPort.HandleError(new SimpleUseCaseError(2, "Add Not Found"));
                return;
            }

            var createEntityUseCaseResponse = new CreateEntityUseCaseResponse(id);

            outputPort.HandleSuccess(createEntityUseCaseResponse);
        }
    }
}
