using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Core.Contracts.Entities;
using CleanArchitectureTemplate.Core.Contracts.Repositories.SqlEngineSpecifications;
using Dapper;

// ReSharper disable RedundantAnonymousTypePropertyName

namespace CleanArchitectureTemplate.Infrastructure.Repositories.DapperRepositories
{
    public class SqlServerDapperRepository<T> : BaseDapperRepository<T> where T : class, IEntity
    {
        protected readonly ISqlServerEngineSpecifications SqlServerEngineSpecifications;

        protected SqlServerDapperRepository(ISqlServerEngineSpecifications sqlServerEngineSpecifications) : base(sqlServerEngineSpecifications)
        {
            SqlServerEngineSpecifications = sqlServerEngineSpecifications;
        }

        public override IEnumerable<T> GetByIds(IEnumerable<long> ids)
        {
            var idsList = ids.ToList();

            if (!idsList.Any())
            {
                return default(IEnumerable<T>);
            }

            IEnumerable<T> allEntities;

            using (var cn = SqlServerEngineSpecifications.CreateAndOpenConnection())
            {
                var query = $"select * from {typeof(T).Name}s where Id in @ids";

                var queryParams = new
                {
                    ids = idsList
                };

                allEntities = cn.Query<T>(query, queryParams);
            }

            return allEntities;
        }

        public override async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<long> ids)
        {
            var idsList = ids.ToList();

            if (!idsList.Any())
            {
                return default(IEnumerable<T>);
            }

            IEnumerable<T> allEntities;

            using (var cn = SqlServerEngineSpecifications.CreateAndOpenConnection())
            {
                var query = $"select * from {typeof(T).Name}s where Id in @ids";

                var queryParams = new
                {
                    ids = idsList
                };

                allEntities = await cn.QueryAsync<T>(query, queryParams);
            }

            return allEntities;
        }

        public override IEnumerable<T> GetAllPaginated(int pageSize, int page)
        {
            IEnumerable<T> allEntities;

            using (var cn = SqlServerEngineSpecifications.CreateAndOpenConnection())
            {
                var query = "DECLARE @_PageSize INT = @pageSize " +
                            "DECLARE @_Page INT = @page " +
                            $"select * from ( select RowNum = ROW_NUMBER() OVER ( ORDER BY Id), * from {typeof(T).Name}s ) AS a where RowNum > (@_PageSize * (@_Page - 1)) and RowNum <= (@_PageSize * (@_Page - 1)) + @_PageSize ORDER BY Id";

                var queryParams = new
                {
                    pageSize = pageSize,
                    page = page
                };

                allEntities = cn.Query<T>(query, queryParams);
            }

            return allEntities;
        }

        public override async Task<IEnumerable<T>> GetAllPaginatedAsync(int pageSize, int page)
        {
            IEnumerable<T> allEntities;

            using (var cn = SqlServerEngineSpecifications.CreateAndOpenConnection())
            {
                var query = "DECLARE @_PageSize INT = @pageSize " +
                            "DECLARE @_Page INT = @page " +
                            $"select * from ( select RowNum = ROW_NUMBER() OVER ( ORDER BY Id), * from {typeof(T).Name}s ) AS a where RowNum > (@_PageSize * (@_Page - 1)) and RowNum <= (@_PageSize * (@_Page - 1)) + @_PageSize ORDER BY Id";

                var queryParams = new
                {
                    pageSize = pageSize,
                    page = page
                };

                allEntities = await cn.QueryAsync<T>(query, queryParams);
            }

            return allEntities;
        }

        public sealed override bool Exists(long id)
        {
            int exists;

            using (var cn = SqlServerEngineSpecifications.CreateAndOpenConnection())
            {
                var query = $"select top 1 1 from {typeof(T).Name}s where Id = @id";

                var queryParams = new
                {
                    id = id
                };

                exists = cn.QuerySingleOrDefault<int>(query, queryParams);
            }

            if (exists == default(int))
            {
                return false;
            }

            return true;
        }

        public sealed override async Task<bool> ExistsAsync(long id)
        {
            int exists;

            using (var cn = SqlServerEngineSpecifications.CreateAndOpenConnection())
            {
                var query = $"select top 1 1 from {typeof(T).Name}s where Id = @id";

                var queryParams = new
                {
                    id = id
                };

                exists = await cn.QuerySingleOrDefaultAsync<int>(query, queryParams);
            }

            if (exists == default(int))
            {
                return false;
            }

            return true;
        }
    }
}
