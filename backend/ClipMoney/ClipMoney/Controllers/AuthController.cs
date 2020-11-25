using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClipMoney.BusinessLogic;
using ClipMoney.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClipMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthBusinessLogic _authBusinessLogic;
        public AuthController()
        {
            _authBusinessLogic = new AuthBusinessLogic();
        }
        // GET: api/<AuthController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("login")]
        public IActionResult Get(UserModel user)
        {
            var token = _authBusinessLogic.LoginUser(user);
            return Ok(token);
        }

        // POST api/<AuthController>
        [HttpPost("sign-in")]
        public IActionResult RegisterUser([FromBody] UserModel newUser)
        {
            _authBusinessLogic.SignInUser(newUser);
            return Ok();
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
