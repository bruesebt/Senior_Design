using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WhatsTheMove.Data.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {            
            _config = config;  
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connId = "WTM-DB-ConnectionString")
        {
            using IDbConnection connection = new SqlConnection(_config[connId]);

            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string connId = "WTM-DB-ConnectionString")
        {
            using IDbConnection connection = new SqlConnection(_config[connId]);

            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
