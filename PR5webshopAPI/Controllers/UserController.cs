using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PR5webshopAPI.Data;
using PR5webshopAPI.Models;
using PR5webshopAPI.Services;

namespace PR5webshopAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private readonly HelloCoreContext _context;

        public UserController(IUserService userService, HelloCoreContext context)
        {
            _userService = userService;
            _context = context;

        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var users = _context.Users.ToList();
            User user = users.Find(u => u.Username == userParam.Username);

            if (user != null && user.Password == userParam.Password)
            {
                user = _userService.Authenticate(user.Id, user.Username, user.Password);
            }
            else
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(user);
        }
    }
}