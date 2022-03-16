using System.Collections.Generic;
using System.Threading.Tasks;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Data.Interfaces
{
    public interface IPreferenceData
    {
        Task<IEnumerable<Preference>> GetPreferences_FromUserId(int id);
        Task DeletePreference(int id);
        Task InsertPreference(Preference preference);
        Task UpdatePreference(Preference preference);
    }
}
