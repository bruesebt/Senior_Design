using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WhatsTheMove.Core.Common
{
    public static class ApiHelper
    {

        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            if (ApiClient == null)
            {
                ApiClient = new HttpClient();
                ApiClient.BaseAddress = new Uri("https://whatsthemovewebapi.azure-api.net/");
                ApiClient.DefaultRequestHeaders.Accept.Clear();
                ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

    }
}
