using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsTheMove.Data.DataAccess;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Data.Interfaces;
using static WhatsTheMove.Data.Common.StoredProcedureConstants;

namespace WhatsTheMove.Data.Implementations
{
    public class SavedActivityData : ISavedActivityData
    {

        private readonly ISqlDataAccess _db;

        public SavedActivityData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<SavedActivity>> GetActivities_FromUserId(int userId) =>
            _db.LoadData<SavedActivity, dynamic>(storedProcedure: $"{Prefix}{nameof(Activity)}{GetAll}_FromUserId",
                                            parameters: new { UserId = userId });

        public async Task<SavedActivity> GetActivity(int id)
        {
            var results = await _db.LoadData<SavedActivity, dynamic>(storedProcedure: $"{Prefix}{nameof(Activity)}{Get}",
                                                                parameters: new { Id = id });

            return results.FirstOrDefault();
        }

        public Task InsertActivity(SavedActivity activity) =>
            _db.SaveData(storedProcedure: $"{Prefix}{nameof(Activity)}{Insert}",
                            parameters: new { activity.UserId, activity.PreferenceId, activity.Place_Id, activity.Name, activity.DateAdded, activity.Rating });

        public Task UpdateActivity(SavedActivity activity) =>
            _db.SaveData(storedProcedure: $"{Prefix}{nameof(Activity)}{Update}",
                            parameters: activity);

        public Task DeleteActivity(int id) =>
            _db.SaveData(storedProcedure: $"{Prefix}{nameof(Activity)}{Delete}",
                            parameters: new { Id = id });

    }
}
