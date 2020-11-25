using ClipMoney.Models;
using ClipMoney.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClipMoney.BusinessLogic
{
    public class AuthBusinessLogic
    {
        private readonly AuthRepository _authRepository;
        public AuthBusinessLogic()
        {
            _authRepository = new AuthRepository();
        }
        public void SignInUser(UserModel user)
        {
            _authRepository.SignInUser(user);
        }

        public string LoginUser(UserModel user)
        {
            try
            {
                var userDb = _authRepository.LoginUser(user);
                if (userDb != null)
                {
                    var token = GenerarJWT(userDb);
                    return token;
                }
                else
                {
                    return "Usuario y/o contraseña incorrectos.";
                }
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
           
        }

        private string GenerarJWT(UserModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("C75D02A9D9E396ABD5FFE60A8C0D6DCFA8AC6C5EB1A9A300AA271140C8C0A0D4"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(24);

            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim("email", user.Email),
                new Claim("name", user.Firstname),
                new Claim("lastname", user.Lastname)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                claims: Claims,
                expires: expiration,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
