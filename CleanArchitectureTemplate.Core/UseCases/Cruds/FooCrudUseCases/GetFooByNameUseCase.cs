using System;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Core.Contracts.Logger;
using CleanArchitectureTemplate.Core.Contracts.Repositories;
using CleanArchitectureTemplate.Core.Contracts.UseCases;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.GetByName;
using CleanArchitectureTemplate.Core.Entities;

namespace CleanArchitectureTemplate.Core.UseCases.Cruds.FooCrudUseCases
{
    public class GetFooByNameUseCase : IGetFooByNameUseCase
    {
        private readonly IFooRepository _fooRepository;
        private readonly ICoreLogger _coreLogger;

        public GetFooByNameUseCase(IFooRepository fooRepository, ICoreLogger coreLogger)
        {
            _fooRepository = fooRepository;
            _coreLogger = coreLogger;
        }

        public void Execute(GetFooByNameUseCaseRequest useCaseRequest, IOutputPort<GetFooByNameUseCaseResponse> outputPort)
        {
            Foo foo;

            try
            {
                foo = _fooRepository.GetByName(useCaseRequest.Name);
            }
            catch (Exception exception)
            {
                _coreLogger.LogError(exception);

                outputPort.HandleError(new SimpleUseCaseError(2, "Unknown Error"));
                return;
            }

            if (foo == default(Foo))
            {
                outputPort.HandleError(new SimpleUseCaseError(1, $"{nameof(Foo)} with {nameof(useCaseRequest.Name)} {useCaseRequest.Name} not exists"));
                return;
            }

            var getFooByNameUseCaseResponse = new GetFooByNameUseCaseResponse(foo);

            outputPort.HandleSuccess(getFooByNameUseCaseResponse);
        }

        public async Task ExecuteAsync(GetFooByNameUseCaseRequest useCaseRequest, IOutputPort<GetFooByNameUseCaseResponse> outputPort)
        {
            throw new NotImplementedException();
        }
    }
}
