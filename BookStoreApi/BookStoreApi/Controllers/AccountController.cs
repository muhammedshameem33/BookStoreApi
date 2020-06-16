using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookStoreModelLayer.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<Users> userManager;
        private readonly IConfiguration config;

        public SignInManager<Users> SignInManager { get; }

        public AccountController(UserManager<Users> userManager, SignInManager<Users> signInManager, IConfiguration config)
        {
            this.userManager = userManager;
            SignInManager = signInManager;
            this.config = config;
        }

        // POST api/<controller>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Users { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, EmailConfirmed = true };
                var result = await this.userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return this.Ok(result);
                }
                else
                {
                    return this.BadRequest(result);
                }
            }

            return this.BadRequest(new { error = "model not valid" });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.SignInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, false);
                if (result.Succeeded)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["Jwt:Key"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,model.Email),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName,model.Email)
                    };
                    var token = new JwtSecurityToken(
                    this.config["Jwt:Issuer"],
                    this.config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);
                    var response = new JwtSecurityTokenHandler().WriteToken(token);
                    return this.Ok(new { Token = response,Email=model.Email });
                }
                else
                {
                    return this.BadRequest(result);
                }
            }
            else
            {
                return this.BadRequest(new { error = "model not valid" });
            }
        }
    }
}
