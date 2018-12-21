using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsSystem.Repository;
using TicketsSystem.Models.Entities;
using System.Security.Claims;
using TicketsSystem.Models.ViewModels.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using TicketsSystem.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using TicketsSystem.Repository.MySql.MySqlCRUD;

namespace TicketsSystem.WebApi
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private IRepository mySqlRepository;
        private UserRepository userRepository;

        public AccountController(IRepository _mySqlRepository)
        {
            mySqlRepository = _mySqlRepository;
            userRepository = (UserRepository)this.mySqlRepository.GetUserCRUD();
        }

        public class AuthOptions
        {
            public const string ISSUER = "MyAuthServer"; // издатель токена
            public const string AUDIENCE = "http://localhost:50287/"; // потребитель токена
            const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
            public const int LIFETIME = 5; // время жизни токена - 1 минута
            public static SymmetricSecurityKey GetSymmetricSecurityKey()
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
            }
        }
        
        [Route("checkAuthorization")]
        [HttpGet]
        [Authorize]
        public IActionResult Test()
        {
            var claims = User.Claims;
            var identity = User.Identity;
            return Ok(User.Identity.Name);
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Token([FromBody]LoginModel model)
        {
            var username = model.Email;
            var password = model.Password;

            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                Response.StatusCode = 400;
                return BadRequest();
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            OurToken token = new OurToken()
            {
                Token = encodedJwt,
                Role = identity.Name
            };


            return Ok(token);

            // сериализация ответа
            //Response.ContentType = "application/json";
            //await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }        


        private ClaimsIdentity GetIdentity(string email, string password)
        {
            User user = userRepository.TryAuthinticateUser(email, password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
       
    }
}