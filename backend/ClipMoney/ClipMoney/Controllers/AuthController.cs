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
        public AuthController(AuthBusinessLogic authBusinessLogic)
        {
            _authBusinessLogic = authBusinessLogic;
        }

        /// <summary>
        /// Verifica las credenciales del usuario y retorna el jwt token.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [Produces(typeof(string))]
        public IActionResult Get(UserModel user)
        {
            var token = _authBusinessLogic.LoginUser(user);
            return Ok(token);
        }

        /// <summary>
        /// Registra un nuevo usuario.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost("sign-in")]
        public IActionResult RegisterUser([FromBody] UserModel newUser)
        {
            _authBusinessLogic.SignInUser(newUser);
            return Ok();
        }
    }
}
