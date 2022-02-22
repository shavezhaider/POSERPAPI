using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using POSERPAPI.Entities.Request;
using POSERPAPI.Entities.Response;
using POSERPAPI.Manager.Command.Account;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

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
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserAuthenticationRequest userForAuthentication)
        {
            var Query = new UserAuthenticationCommand(userForAuthentication);
            var user = await CommandAsync(Query);
            if (user != null)
            {
                var signingCredentials = _jwtHandler.GetSigningCredentials();
                var claims = _jwtHandler.GetClaims(user);
                var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new UserAuthenticationResponse { IsAuthSuccessful = true, Token = token });
            }
            else
                return Ok(new UserAuthenticationResponse { IsAuthSuccessful = false, Token = "", ErrorMessage = "Invalid Authentication" });



        }
        [AllowAnonymous]
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] AppUserRequest appUserRequest)
        {

            var Query = new AppUserCommand(appUserRequest);
            var user = await CommandAsync(Query);

            return Single(user);
        }

        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest appUserRequest)
        {
            var Query = new ForgotPasswordCommand(appUserRequest);
            var user = await CommandAsync(Query);
            return Single(user);
        }

        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest appUserRequest)
        {
            //var Query = new ForgotPasswordCommand(appUserRequest);
            //var user = await CommandAsync(Query);
            //return Single(user);
            return null;
        }

        [AllowAnonymous]
        [HttpGet("all")]
        public string all()
        {
            //var Query = new ForgotPasswordCommand(appUserRequest);
            //var user = await CommandAsync(Query);
            //return Single(user);
            return "hello test";
        }
    }
}
