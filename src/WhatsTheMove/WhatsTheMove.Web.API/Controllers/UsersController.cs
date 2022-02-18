using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return null;
        }

        [HttpGet]
        [Route("{id:int}")]
        public User Get(int id)
        {
            return null;
        }

        [HttpGet]
        [Route("{username}")]
        public User Get(string username)
        {
            return null;
        }
    }
}
