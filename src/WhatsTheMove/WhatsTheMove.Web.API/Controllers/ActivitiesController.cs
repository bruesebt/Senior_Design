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
        [Route("Nearby/")]
        public async Task<IActionResult> GetActivities_Nearby(string zipCode, 
                                                                int? radius = null, 
                                                                string keyword = null, 
                                                                string type = null,
                                                                int? budget = null)
        {
            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(await SearchString(zipCode, radius, keyword, type, budget)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string results = await response.Content.ReadAsStringAsync();

                        PlacesApiResultsRoot root = JsonConvert.DeserializeObject<PlacesApiResultsRoot>(results);

                        return Ok(root.Results);
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
        
        [HttpGet]
        public async Task<string> GetLocation(string zipCode)
        {
            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"geocode/json?address={zipCode}&key={_placesAccess.AccessKey}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string results = await response.Content.ReadAsStringAsync();

                        return results;

                        //GeoApiResultsRoot root = JsonConvert.DeserializeObject<GeoApiResultsRoot>(results);

                       // return root.Results.First().Geometry.Location;
                    }
                    else
                    {
                        throw new Exception($"Exception when getting latitude and longitude. Reason: {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception when getting latitude and longitude. Error message: {ex.Message}");
            }            
        }

        private async Task<string> SearchString(string zipCode,
                                    int? radius = null,
                                    string keyword = null,
                                    string type = null,
                                    int? budget = null)
        {
            //Location loc = await GetLocation(zipCode);
            Location loc = new Location();
            string searchString = $"place/{Places.SearchType.NearbySearch.ToString().ToLower()}/json?";
            searchString += keyword == null ? string.Empty : $"keyword={keyword}&";
            searchString += $"location={loc.Lat}%2C{loc.Lng}";
            searchString += radius == null ? $"&rankby=distance" : $"&radius={radius}";
            searchString += type == null ? string.Empty : $"&type={type}";
            searchString += budget == null ? string.Empty : $"&minprice={budget}";
            searchString += $"&key={_placesAccess.AccessKey}";

            return searchString;
        }
    }
}
