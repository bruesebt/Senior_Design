using System.Collections.Generic;
using System.Threading.Tasks;

namespace WhatsTheMove.Data.DataAccess
{
    public interface ISqlDataAccess
    {
        protected const string ConnectionString = "WTM-DB-ConnectionString";

        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connId = ConnectionString);
        Task SaveData<T>(string storedProcedure, T parameters, string connId = ConnectionString);
    }
}