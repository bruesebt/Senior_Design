using System.Threading.Tasks;
using System.Collections.Generic;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Data.Interfaces
{
    public interface ISavedActivityData
    {
        Task DeleteActivity(int id);
        Task<IEnumerable<SavedActivity>> GetActivities_FromUserId(int userId);
        Task<SavedActivity> GetActivity(int id);        
        Task InsertActivity(SavedActivity activity);
        Task UpdateActivity(SavedActivity activity);

    }
}
