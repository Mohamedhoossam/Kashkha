using Kashkha.BL.DTOs.UserDTOS;
using Kashkha.BL.Helpers;
using Kashkha.DAL;
using Kashkha.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using StackExchange.Redis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kashkha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<User> _userManager,IConfiguration _configuration)
        {
            userManager = _userManager;
            configuration = _configuration;
        }

        #region Register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO _reginfo)
        {
            //assign user data from dto to database
            if (ModelState.IsValid)
            {
                var usr = new User()
                {
                    Rolename=_reginfo.Rolename !,
                    UserName = _reginfo.Name,
                    Email = _reginfo.Email,
                    PhoneNumber = _reginfo.Phone,
                    ShopName = _reginfo.ShopName,
                    Shop = _reginfo.Shop,
                    Address = _reginfo.Address,
                    Category = _reginfo.Category,
                    ImgUrl = _reginfo.ImgUrl
                    

                };
                var result = await userManager.CreateAsync(usr, _reginfo.Password);
                //check
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
                var claims = new List<Claim>
            {
               new (ClaimTypes.NameIdentifier,usr.Id.ToString()),
               new (ClaimTypes.Name,usr.UserName),
               new (ClaimTypes.Email,usr.Email),
               new(ClaimTypes.Role,usr.Rolename)
               };
               
                await userManager.AddClaimsAsync(usr, claims);

                return Ok("sucessed");
            }
            var errors=ModelState.Values.Select(x=>x.Errors.Select(y=>y.ErrorMessage));
            return BadRequest(errors);
        }
        #endregion



        #region Login
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDTO loginDto)
        {
            var  user = await userManager.FindByNameAsync(loginDto.UserName);
            if (user == null)
            {
                return Unauthorized("user not found"); // 401
            }

            bool isAuthenticated = await userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isAuthenticated)
            {
                return Unauthorized("password is incorrect"); // 401
            }

            var userClaims = await userManager.GetClaimsAsync(user);
            CreateToken token = new CreateToken();

            return token.GenerateToken(userClaims);
        }
        #endregion

        #region test
        [HttpPost("check")]
        [Authorize(Roles ="Shop Owner")]
        public IActionResult shopcheck()
        {
            return Ok("hey shop owner");
        }
        #endregion

       

    }
}
