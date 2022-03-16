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
    public class SavedActivitiesController : Controller
    {
        private readonly ISavedActivityData _savedActivityData;

        public SavedActivitiesController(ISavedActivityData savedActivityData)
        {
            _savedActivityData = savedActivityData;
        }

        [HttpGet]
        [Route("User/{userId:int}")]
        public async Task<IActionResult> GetSavedActivities(int userId)
        {
            try
            {
                return Ok(await _savedActivityData.GetActivities_FromUserId(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetSavedActivity(int id)
        {
            try
            {
                return Ok(await _savedActivityData.GetActivity(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertSavedActivity(SavedActivity activity)
        {
            try
            {
                await _savedActivityData.InsertActivity(activity);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSavedActivity(SavedActivity activity)
        {
            try
            {
                await _savedActivityData.UpdateActivity(activity);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSavedActivity(int id)
        {
            try
            {
                await _savedActivityData.DeleteActivity(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
