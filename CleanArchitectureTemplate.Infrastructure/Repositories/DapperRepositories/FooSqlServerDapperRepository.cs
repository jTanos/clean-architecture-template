using System;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Core.Contracts.Repositories;
using CleanArchitectureTemplate.Core.Contracts.Repositories.SqlEngineSpecifications;
using CleanArchitectureTemplate.Core.Entities;
using Dapper;

// ReSharper disable RedundantAnonymousTypePropertyName
// ReSharper disable RedundantTernaryExpression

namespace CleanArchitectureTemplate.Infrastructure.Repositories.DapperRepositories
{
    public class FooSqlServerDapperRepository : SqlServerDapperRepository<Foo>, IFooRepository
    {
        public FooSqlServerDapperRepository(ISqlServerEngineSpecifications sqlEngineSpecifications) : base(sqlEngineSpecifications)
        {
        }

        public Foo GetByName(string name)
        {
            Foo fooToReturn;

            using (var cn = SqlServerEngineSpecifications.CreateAndOpenConnection())
            {
                const string getByNameQuery = "select m.Id, m.Name " +
                                               "where m.Name = @Name;";

                var getByNameParams = new { Name = name };

                fooToReturn = cn.Query<Foo>(getByNameQuery, getByNameParams)
                                    .FirstOrDefault();
            }

            return fooToReturn;
        }

        public async Task<Foo> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}