using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Web.API.Places;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace WhatsTheMove.Web.API.Common
{
    public class ApiHelper
    {

        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            if (ApiClient == null)
            {
                ApiClient = new HttpClient();
                ApiClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/");
                ApiClient.DefaultRequestHeaders.Accept.Clear();
                ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }       
    }
}
