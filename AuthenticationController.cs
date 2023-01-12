using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

//more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTAuthentication
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        public static User user = new User();

        [HttpPost("Register")]
        public ActionResult<User> Register(UserDetails request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.UserName = request.Username;
            user.PassswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user);
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt  )
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}

