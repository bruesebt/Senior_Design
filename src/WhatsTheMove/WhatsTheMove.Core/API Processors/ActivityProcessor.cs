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
        public static async Task<IEnumerable<Activity>> PerformNearbySearch(Preference preference)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<IEnumerable<Activity>> PerformDetailsSearch(IEnumerable<SavedActivity> savedActivities)
        {
            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"Activities/Details?placeIdsCsv={savedActivities.Select(sa => sa.Place_Id).ToCSV()}"))
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> PerformLocationSearch(string zipCode)
        {
            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"Activities/?zipCode={zipCode}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string results = await response.Content.ReadAsAsync<string>();

                        return results;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string SearchString(Preference preference)
        {
            string searchString = $"zipCode={preference.ZipCode}";
            searchString += preference.Distance == null ? string.Empty : $"&radius={((int)preference.Distance).ToMeters()}";
            searchString += preference.IsFoodRequested != null && (bool)preference.IsFoodRequested ? $"&keyword=food" : string.Empty;
            searchString += preference.IsDrinksRequested != null && (bool)preference.IsDrinksRequested ? $"&type=bar" : string.Empty;
            searchString += preference.Budget == null ? string.Empty : $"&budget={preference.Budget}";

            return searchString;
        }

        /// <summary>
        /// An approximate conversion of miles to meters
        /// </summary>
        /// <param name="miles"></param>
        /// <returns></returns>
        private static int ToMeters(this int miles) => miles * 1609;
    }
}
