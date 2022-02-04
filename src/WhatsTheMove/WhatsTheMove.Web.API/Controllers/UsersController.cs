using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsTheMove.Data.Library.Models;

namespace WhatsTheMove.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Data.Library.DummyData.TestUsers;
        }

        [HttpGet]
        [Route("{id:int}")]
        public User Get(int id)
        {
            return Data.Library.DummyData.TestUsers.Where(u => u.ID == id).First();
        }

        [HttpGet]
        [Route("{username}")]
        public User Get(string username)
        {
            return Data.Library.DummyData.TestUsers.Where(u => u.Username == username).First();
        }
    }
}
