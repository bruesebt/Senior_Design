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
    public class PreferenceData : IPreferenceData
    {

        private readonly ISqlDataAccess _db;

        public PreferenceData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<Preference>> GetPreferences_FromUserId(int userId) =>
            _db.LoadData<Preference, dynamic>(storedProcedure: $"{Prefix}{nameof(Preference)}{GetAll}_FromUserId",
                                                    parameters: new { UserId = userId });

        public Task InsertPreference(Preference preference) =>
            _db.SaveData(storedProcedure: $"{Prefix}{nameof(Preference)}{Insert}",
                            parameters: new { preference.UserId, preference.GroupSize, preference.IsFoodRequested, preference.IsDrinksRequested, preference.EnergyLevel, preference.Budget, preference.TimeOfDay, preference.DressCode });

        public Task UpdatePreference(Preference preference) =>
            _db.SaveData(storedProcedure: $"{Prefix}{nameof(Preference)}{Update}",
                            parameters: preference);

        public Task DeletePreference(int id) =>
            _db.SaveData(storedProcedure: $"{Prefix}{nameof(Preference)}{Delete}",
                            parameters: new { Id = id });
    }
}
