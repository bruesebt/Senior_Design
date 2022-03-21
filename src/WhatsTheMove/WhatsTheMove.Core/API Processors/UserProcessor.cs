using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WhatsTheMove.Core.Common;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Core.API
{
    public static class UserProcessor
    {

        /// <summary>
        /// Calls api to get all users
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<User>> LoadUsers()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync("Users"))
            {
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<User> users = await response.Content.ReadAsAsync<IEnumerable<User>>();

                    return users;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Calls api to get user of specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<User> LoadUser(int id)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"Users/UserId/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    User user = await response.Content.ReadAsAsync<User>();

                    return user;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Calls api to get user of specific username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static async Task<User> LoadUser(string username)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"Users/Username/{username}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    User user = await response.Content.ReadAsAsync<User>();

                    return user;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Calls api to get user of specific email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static async Task<User> LoadUser_FromEmail(string email)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"Users/Email/{email}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    User user = await response.Content.ReadAsAsync<User>();

                    return user;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Calls api to create new user, returns the created user
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public static async Task<User> CreateUser(User newUser)
        {
            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync<User>($"Users", newUser))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        User user = await LoadUser(newUser.Username);

                        return user;
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

        /// <summary>
        /// Calls api to update the passed in user. Returns updated user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<User> UpdateUser(User user)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync<User>("Users", user))
            {
                if (response.IsSuccessStatusCode)
                {
                    user = await LoadUser(user.Username);

                    return user;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Calls api to delete the user of the passed in id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task DeleteUser(int id)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync($"Users?id={id}"))
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
