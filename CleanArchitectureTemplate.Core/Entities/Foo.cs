using CleanArchitectureTemplate.Core.Contracts.Entities;

namespace CleanArchitectureTemplate.Core.Entities
{
    public class Foo : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
