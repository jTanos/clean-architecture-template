using System;

namespace CleanArchitectureTemplate.Core.Contracts.Logger
{
    public interface ICoreLogger
    {
        void LogError(Exception exception, string message = null);
    }
}
