using System.Collections.Generic;
using System.Threading.Tasks;

namespace WhatsTheMove.Data.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connId = "WTM-DB-ConnectionString");
        Task SaveData<T>(string storedProcedure, T parameters, string connId = "WTM-DB-ConnectionString");
    }
}