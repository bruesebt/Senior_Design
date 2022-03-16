using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsTheMove.Data.Interfaces;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreferencesController : Controller
    {
        private readonly IPreferenceData _preferenceData;

        public PreferencesController(IPreferenceData preferenceData)
        {
            _preferenceData = preferenceData;
        }

        [HttpGet]
        [Route("{userId:int}")]
        public async Task<IActionResult> GetPreferences(int userId)
        {
            try
            {
                return Ok(await _preferenceData.GetPreferences_FromUserId(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertPreference(Preference preference)
        {
            try
            {
                await _preferenceData.InsertPreference(preference);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePreference(Preference preference)
        {
            try
            {
                await _preferenceData.UpdatePreference(preference);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePreference(int id)
        {
            try
            {
                await _preferenceData.DeletePreference(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
