using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Microsoft.EntityFrameworkCore;
using Capstone.Helpers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

namespace Capstone.Controllers
{
    [ApiController]
    [EnableCors]
    public class UserController : Controller
    {
        private readonly ApplicationDBContext _context;

        public UserController()
        {
            _context = new ApplicationDBContext();
        }


        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get() //get user list
        {
            return new JsonResult(await _context.Users.ToListAsync());
        }

        [HttpPost]
        [Route("api/[controller]/addUser")]
        public async Task<IActionResult> Post(User user) //add new user
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new JsonResult(" User Added successfully");
        }


           
    }
}
