using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using POSERPAPI.Entities.Request;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace POSERPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiControllerBase
    {
        //private readonly UserManager<User> _userManager;
       // private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;

        public AccountController(IMediator mediator, JwtHandler jwtHandler) : base(mediator)
        {
            _jwtHandler = jwtHandler;

        }

        //public AccountsController(UserManager<User> userManager, IMapper mapper, JwtHandler jwtHandler)
        //{
        //    _userManager = userManager;
        //    _mapper = mapper;
        //    _jwtHandler = jwtHandler;
        //}

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserAuthenticationRequest userForAuthentication)
        {
            //var user = await _userManager.FindByNameAsync(userForAuthentication.Email);
            //if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
            //    return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            //var signingCredentials = _jwtHandler.GetSigningCredentials();
            //var claims = _jwtHandler.GetClaims(user);
            //var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
           // var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new UserAuthenticationResponse { IsAuthSuccessful = true, Token = "" });
        }
    }
}
