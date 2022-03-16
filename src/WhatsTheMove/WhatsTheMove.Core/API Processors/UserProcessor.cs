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

    }
}
