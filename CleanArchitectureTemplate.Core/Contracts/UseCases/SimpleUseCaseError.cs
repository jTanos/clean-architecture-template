namespace CleanArchitectureTemplate.Core.Contracts.UseCases
{
    public class SimpleUseCaseError : IUseCaseError
    {
        public int Code { get; }

        public string Message { get; }

        public SimpleUseCaseError(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
