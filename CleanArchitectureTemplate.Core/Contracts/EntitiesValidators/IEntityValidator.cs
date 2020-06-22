using CleanArchitectureTemplate.Core.Contracts.Entities;

namespace CleanArchitectureTemplate.Core.Contracts.EntitiesValidators
{
    public interface IEntityValidator<in T> where T : class, IEntity
    {
        bool IsValid(T entity);
    }
}
