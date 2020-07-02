using System;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Core.Contracts.Entities;
using CleanArchitectureTemplate.Core.Contracts.EntitiesValidators;
using CleanArchitectureTemplate.Core.Contracts.Logger;
using CleanArchitectureTemplate.Core.Contracts.Repositories;
using CleanArchitectureTemplate.Core.Contracts.UseCases;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Update;

namespace CleanArchitectureTemplate.Core.UseCases.Cruds.EntityCrudUseCases
{
    public class UpdateEntityUseCase<T> : IUpdateEntityUseCase<T> where T : class, IEntity
    {
        protected readonly IRepository<T> Repository;
        protected readonly IEntityValidator<T> EntityValidator;
        protected readonly ICoreLogger CoreLogger;

        protected UpdateEntityUseCase(IRepository<T> repository, IEntityValidator<T> entityValidator, ICoreLogger coreLogger)
        {
            Repository = repository;
            EntityValidator = entityValidator;
            CoreLogger = coreLogger;
        }

        public virtual void Execute(UpdateEntityUseCaseRequest<T> useCaseRequest, IOutputPort<UpdateEntityUseCaseResponse> outputPort)
        {
            if (!EntityValidator.IsValid(useCaseRequest.Entity))
            {
                outputPort.HandleError(new SimpleUseCaseError(1, "Not Valid Entity"));
                return;
            }

            bool updated;

            try
            {
                 updated = Repository.Update(useCaseRequest.Entity);
            }
            catch (Exception exception)
            {
                CoreLogger.LogError(exception);

                outputPort.HandleError(new SimpleUseCaseError(2, "Update Not Found"));
                return;
            }

            if (!updated)
            {
                outputPort.HandleError(new SimpleUseCaseError(2, "Update Not Found"));
                return;
            }

            var updateEntityUseCaseResponse = new UpdateEntityUseCaseResponse(useCaseRequest.Entity.Id);

            outputPort.HandleSuccess(updateEntityUseCaseResponse);
        }

        public virtual async Task ExecuteAsync(UpdateEntityUseCaseRequest<T> useCaseRequest, IOutputPort<UpdateEntityUseCaseResponse> outputPort)
        {
            if (!EntityValidator.IsValid(useCaseRequest.Entity))
            {
                outputPort.HandleError(new SimpleUseCaseError(1, "Not Valid Entity"));
                return;
            }

            bool updated;

            try
            {
                updated = await Repository.UpdateAsync(useCaseRequest.Entity);
            }
            catch (Exception exception)
            {
                CoreLogger.LogError(exception);

                outputPort.HandleError(new SimpleUseCaseError(2, "Update Not Found"));
                return;
            }

            if (!updated)
            {
                outputPort.HandleError(new SimpleUseCaseError(2, "Update Not Found"));
                return;
            }

            var updateEntityUseCaseResponse = new UpdateEntityUseCaseResponse(useCaseRequest.Entity.Id);

            outputPort.HandleSuccess(updateEntityUseCaseResponse);
        }
    }
}
