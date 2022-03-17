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
    public static class ActivityProcessor
    {
        public static async Task<IEnumerable<Activity>> PerformNearbySearch(User user, Preference preference)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"Activities/Nearby?{SearchString(preference)}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<Activity> activities = await response.Content.ReadAsAsync<IEnumerable<Activity>>();

                    return activities;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static string SearchString(Preference preference)
        {
            string searchString = $"zipCode={preference.ZipCode}";
            searchString += preference.Distance == null ? string.Empty : $"&radius={preference.Distance}";
            searchString += preference.IsFoodRequested != null && (bool)preference.IsFoodRequested ? $"&keyword=food" : string.Empty;
            searchString += preference.IsDrinksRequested != null && (bool)preference.IsDrinksRequested ? $"&type=bar" : string.Empty;
            searchString += preference.Budget == null ? string.Empty : $"&budget={preference.Budget}";

            return searchString;
        }
    }
}
