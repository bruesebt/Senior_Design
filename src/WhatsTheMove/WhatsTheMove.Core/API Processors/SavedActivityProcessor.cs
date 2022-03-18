using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WhatsTheMove.Core.Common;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Core.API
{
    public static class SavedActivityProcessor
    {

        /// <summary>
        /// Calls api to get saved activities of specific user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<SavedActivity>> LoadSavedActivities(int userId)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"SavedActivities/UserId/{userId}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<SavedActivity> activities = await response.Content.ReadAsAsync<IEnumerable<SavedActivity>>();

                    return activities;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Calls api to get saved activity of specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<SavedActivity> LoadSavedActivity(int id)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"SavedActivities/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    SavedActivity savedActivity = await response.Content.ReadAsAsync<SavedActivity>();

                    return savedActivity;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Calls api to create new saved activity, returns the created saved activity
        /// </summary>
        /// <param name="newSavedActivity"></param>
        /// <returns></returns>
        public static async Task<SavedActivity> CreateSavedActivity(SavedActivity newSavedActivity)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync<SavedActivity>($"SavedActivities", newSavedActivity))
            {
                if (response.IsSuccessStatusCode)
                {
                    SavedActivity savedActivity = await LoadSavedActivity(4);

                    return savedActivity;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Calls api to update the passed in saved activity. Returns updated saved activity
        /// </summary>
        /// <param name="savedActivity"></param>
        /// <returns></returns>
        public static async Task<SavedActivity> UpdateSavedActivity(SavedActivity savedActivity)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync<SavedActivity>("SavedActivities", savedActivity))
            {
                if (response.IsSuccessStatusCode)
                {
                    savedActivity = await LoadSavedActivity(savedActivity.Id);

                    return savedActivity;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Calls api to delete the saved activity of the passed in id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task DeleteSavedActivity(int id)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync($"SavedActivities?id={id}"))
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
