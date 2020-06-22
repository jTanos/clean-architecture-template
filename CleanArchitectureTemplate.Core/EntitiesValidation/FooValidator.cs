using CleanArchitectureTemplate.Core.Contracts.EntitiesValidators;
using CleanArchitectureTemplate.Core.Entities;

namespace CleanArchitectureTemplate.Core.EntitiesValidation
{
    public class FooValidator : IFooValidator
    {
        public bool IsValid(Foo foo)
        {
            return true;
        }
    }
}
