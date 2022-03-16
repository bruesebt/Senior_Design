using Microsoft.AspNetCore.Mvc;
using WhatsTheMove.Web.API.Common;
using WhatsTheMove.Data.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace WhatsTheMove.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivitiesController : Controller
    {
        private readonly IPlacesAccess _placesAccess;

        public ActivitiesController(IPlacesAccess placesAccess)
        {
            _placesAccess = placesAccess;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities(double lat, double lon, int radius, string types, string name)
        {
            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"nearbysearch/json?location={lat},{lon}&radius={radius}&types={types}&name={name}&key={_placesAccess.AccessKey}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string results = await response.Content.ReadAsStringAsync();

                        PlacesApiResultsRoot myDeserializedClass = JsonConvert.DeserializeObject<PlacesApiResultsRoot>(results);

                        return Ok(myDeserializedClass.Results);
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
