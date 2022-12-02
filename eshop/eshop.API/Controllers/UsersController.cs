using eshop.API.Models;
using eshop.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.ValidateUser(viewModel.UserName, viewModel.Password);
                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BU-CUMLE-COK-GIZLI-VE-ONEMLI"));
                    var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        issuer: "https://identity.halkbank.com.tr",
                        audience: "https://client.halkbank.com.tr",
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: credential
                        );

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                return BadRequest(new { message = "Kullanıcı adı ya da şifre yanlış" });
            }
            return BadRequest(ModelState);
        }
    }
}
