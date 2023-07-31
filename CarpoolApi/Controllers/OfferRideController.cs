using CarPool.Data;
using Carpool.Services.Interface;
using Microsoft.AspNetCore.Mvc;
namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OfferRideController : ControllerBase
    {
        private readonly IOfferRideService _offerRideService;

        public OfferRideController(IOfferRideService offerRideService)
        {
            _offerRideService = offerRideService;
        }

        [HttpPost("")]
        public async Task<IActionResult> OfferARide([FromBody] OfferRide offerRide)
        {
            try
            {
                
                OfferRide result = await _offerRideService.AddOfferingRide(offerRide);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Internal Server Error"); 
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> GetOfferedRides([FromQuery] string email)
        {
            try
            {
               
                List<OfferRide> result = await _offerRideService.GetOfferedRide(email);
                return Ok(result); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error"); 
            }
        }
    }
}
