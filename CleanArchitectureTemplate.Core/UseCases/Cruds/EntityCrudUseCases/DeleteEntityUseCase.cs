using System;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Core.Contracts.Entities;
using CleanArchitectureTemplate.Core.Contracts.Log;
using CleanArchitectureTemplate.Core.Contracts.Repositories;
using CleanArchitectureTemplate.Core.Contracts.UseCases;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Delete;

namespace CleanArchitectureTemplate.Core.UseCases.Cruds.EntityCrudUseCases
{
    public class DeleteEntityUseCase<T> : IDeleteEntityUseCase<T> where T : class, IEntity, new()
    {
        protected readonly IRepository<T> Repository;
        protected readonly ICoreLogger CoreLogger;

        protected DeleteEntityUseCase(IRepository<T> repository, ICoreLogger coreLogger)
        {
            Repository = repository;
            CoreLogger = coreLogger;
        }

        public virtual void Execute(DeleteEntityUseCaseRequest useCaseRequest, IOutputPort<DeleteEntityUseCaseResponse> outputPort)
        {
            var entityToBeDeleted = new T { Id = useCaseRequest.Id };

            bool deleted;

            try
            {
                 deleted = Repository.Delete(entityToBeDeleted);
            }
            catch (Exception exception)
            {
                CoreLogger.LogError(exception);

                outputPort.HandleError(new SimpleUseCaseError(1, "Delete Not Found"));
                return;
            }

            if (!deleted)
            {
                outputPort.HandleError(new SimpleUseCaseError(1, "Delete Not Found"));
                return;
            }

            var deleteEntityUseCaseResponse = new DeleteEntityUseCaseResponse(useCaseRequest.Id);

            outputPort.HandleSuccess(deleteEntityUseCaseResponse);
        }

        public virtual async Task ExecuteAsync(DeleteEntityUseCaseRequest useCaseRequest, IOutputPort<DeleteEntityUseCaseResponse> outputPort)
        {
            var entityToBeDeleted = new T { Id = useCaseRequest.Id };

            bool deleted;

            try
            {
                deleted = await Repository.DeleteAsync(entityToBeDeleted);
            }
            catch (Exception exception)
            {
                CoreLogger.LogError(exception);

                outputPort.HandleError(new SimpleUseCaseError(1, "Delete Not Found"));
                return;
            }

            if (!deleted)
            {
                outputPort.HandleError(new SimpleUseCaseError(1, "Delete Not Found"));
                return;
            }

            var deleteEntityUseCaseResponse = new DeleteEntityUseCaseResponse(useCaseRequest.Id);

            outputPort.HandleSuccess(deleteEntityUseCaseResponse);
        }
    }
}
