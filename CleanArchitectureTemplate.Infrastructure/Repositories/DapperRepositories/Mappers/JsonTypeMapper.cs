using System;
using System.Data;
using Dapper;
using Newtonsoft.Json;

namespace CleanArchitectureTemplate.Infrastructure.Repositories.DapperRepositories.Mappers
{
    public class JsonTypeMapper : SqlMapper.ITypeHandler
    {
        public void SetValue(IDbDataParameter parameter, object value)
        {
            if (value == DBNull.Value)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = JsonConvert.SerializeObject(value);
            }
        }

        public object Parse(Type destinationType, object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }

            return JsonConvert.DeserializeObject(value as string, destinationType);
        }
    }
}