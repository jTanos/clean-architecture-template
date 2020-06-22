namespace CleanArchitectureTemplate.Core.Contracts.UseCases
{
    public interface IUseCaseError
    {
        int Code { get; }

        string Message { get; }
    }
}
