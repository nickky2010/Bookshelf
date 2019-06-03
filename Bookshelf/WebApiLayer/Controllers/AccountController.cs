using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BLL.DTO.Identity;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Text;

namespace TokenApp.Controllers
{
    public class AccountController : Controller
    {
        IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [Route("api/token")]
        [HttpPost]
        public async Task<IActionResult> Token([FromBody]UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                throw new BadRequestException(_accountService.UnitOfWorkExceptionMessage.DataException.DataIsNotValid);
            var userIdentified = await _accountService.GetUserAsync(userViewModel);
            if (userIdentified == null)
                throw new UnauthorizedException(_accountService.UnitOfWorkExceptionMessage.UsersException.InvalidLoginAndOrPassword);
            UserDTO userDTO = userIdentified;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, "data"),
                new Claim(JwtRegisteredClaimNames.Sub, "data"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, userDTO.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userDTO.Role.Name)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("rlyaKithdrYVl6Z80ODU350md")); //Secret
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken("me",
                "you",
                claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds);
            return Ok(new
            {
                access_token = new JwtSecurityTokenHandler().WriteToken(token),
                expires_in = DateTime.Now.AddMinutes(10),
                token_type = "bearer"
            });
        }

        // POST api/<controller>
        [AllowAnonymous]
        [Route("api/postUser")]
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody]UserViewModel userViewModel)
        {
            if (userViewModel == null)
                throw new BadRequestException(_accountService.UnitOfWorkExceptionMessage.DataException.NoData);
            if (userViewModel.Role.Name == "admin")
                throw new ForbiddenException(_accountService.UnitOfWorkExceptionMessage.UsersException.СreatingWithRoleIsProhibited("admin"));
            if (!ModelState.IsValid)
                throw new BadRequestException(_accountService.UnitOfWorkExceptionMessage.DataException.DataIsNotValid);
            return Ok(await _accountService.AddUserAsync(userViewModel));
        }

        [Authorize(Roles = "admin")]
        [Route("api/postRole")]
        [HttpPost]
        public async Task<IActionResult> PostRole([FromBody]RoleViewModel value)
        {
            if (value == null)
                throw new BadRequestException(_accountService.UnitOfWorkExceptionMessage.DataException.NoData);
            if (!ModelState.IsValid)
                throw new BadRequestException(_accountService.UnitOfWorkExceptionMessage.DataException.DataIsNotValid);
            return Ok(await _accountService.AddRoleAsync(value));
        }
    }
}