using System.Collections.Generic;

namespace CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.GetAll
{
    public class GetAllEntityUseCaseResponse<T> : IUseCaseResponse
    {
        public IEnumerable<T> Entities { get; }

        public GetAllEntityUseCaseResponse(IEnumerable<T> entities)
        {
            Entities = entities;
        }
    }
}
