using CarPool.Data;
using Carpool.Services.Interaface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarPool.Models;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        ILoginService _loginService;

        public AuthController(IConfiguration configuration, ILoginService loginService)
        {
            _configuration = configuration;
            _loginService = loginService;
        }


        [AllowAnonymous]
        [HttpPost("Register")]
        [Produces("application/json")]
        public async Task<IActionResult> Register([FromBody] Credentials credentials)
        {
            try
            {
                RegistrationResponse result = await _loginService.Register(credentials);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [Produces("application/json")]
        public async Task<IActionResult> Login([FromBody] Credentials credentials)
        {
            try
            {
                CredentialsResponse result = await _loginService.SignIn(credentials);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("User not found or invalid credentials");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
