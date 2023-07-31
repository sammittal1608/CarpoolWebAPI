using Carpool.Services.Interface;
using CarPool.Data;
using Microsoft.AspNetCore.Mvc;
namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailsService _userDetailsService;

        public UserDetailsController(IUserDetailsService userDetailsService)
        {
            _userDetailsService = userDetailsService;
        }

        [HttpGet("Email")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserDetails([FromQuery] string Email)
        {
            try
            {
                User userDetails = await _userDetailsService.GetUserDetailsByEmail(Email);
                if (userDetails != null)
                {
                    return Ok(userDetails);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("Update")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateUserDetails([FromBody] User oldUserDetails)
        {
            try
            {
                User updatedUserDetails = await _userDetailsService.UpdateUserDetails(oldUserDetails);
                if (updatedUserDetails != null)
                {
                    return Ok(updatedUserDetails);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
