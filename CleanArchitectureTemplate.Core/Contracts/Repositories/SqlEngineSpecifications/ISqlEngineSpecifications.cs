using System.Data;

namespace CleanArchitectureTemplate.Core.Contracts.Repositories.SqlEngineSpecifications
{
    public interface ISqlEngineSpecifications
    {
        IDbConnection CreateAndOpenConnection();

        string LastIdentityValueInsertedQuery();
    }
}
