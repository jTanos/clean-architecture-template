using System.Threading.Tasks;
using CleanArchitectureTemplate.Core.Entities;

namespace CleanArchitectureTemplate.Core.Contracts.Repositories
{
    public interface IFooRepository : IRepository<Foo>
    {
        Foo GetByName(string name);

        Task<Foo> GetByNameAsync(string name);
    }
}
