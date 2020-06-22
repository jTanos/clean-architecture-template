namespace CleanArchitectureTemplate.Core.Contracts.UseCases
{
    public interface IOutputPort<in T> where T : IUseCaseResponse
    {
        void HandleSuccess(T useCaseSuccessResponse);

        void HandleError(IUseCaseError useCaseError);
    }
}
