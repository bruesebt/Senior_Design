using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WhatsTheMove.Core.Common;
using WhatsTheMove.Data.Models;
using System.Linq;

namespace WhatsTheMove.Core.API
{
    public static class PreferenceProcessor
    {

        /// <summary>
        /// Calls api to get preferences of specific user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<Preference>> LoadPreferences(int userId)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"Preferences/{userId}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<Preference> preferences = await response.Content.ReadAsAsync<IEnumerable<Preference>>();

                    return preferences;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Calls api to create new preference, returns the created preference
        /// </summary>
        /// <param name="newPreference"></param>
        /// <returns></returns>
        public static async Task<Preference> CreatePreference(Preference newPreference)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync<Preference>($"Preferences", newPreference))
            {
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<Preference> preferences = await LoadPreferences(newPreference.UserId);

                    return preferences.OrderByDescending(p => p.Id).FirstOrDefault();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Calls api to update the passed in preference. Returns updated preference
        /// </summary>
        /// <param name="preference"></param>
        /// <returns></returns>
        public static async Task<Preference> UpdatePreference(Preference preference)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync<Preference>("Preferences", preference))
            {
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<Preference> preferences = await LoadPreferences(preference.UserId);

                    return preferences.Where(p => p.Id == preference.Id).FirstOrDefault();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Calls api to delete the preference of the passed in id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task DeletePreference(int id)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync($"Preferences?id={id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
