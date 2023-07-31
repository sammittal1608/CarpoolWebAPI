using CarPool.Data;
using Carpool.Services.Interaface;
using Microsoft.AspNetCore.Mvc;
namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchingRideController : ControllerBase
    {
        private readonly IMatchingRidesService _matchingRidesService;

        public MatchingRideController(IMatchingRidesService matchingRidesService)
        {
            _matchingRidesService = matchingRidesService;
        }

        [HttpGet]
        [Produces("application/json")] 
        public async Task<IActionResult> GetMatchingRide([FromQuery] MatchingRideRequest matchingRide)
        {
            List<MatchingRideResponse> result = await _matchingRidesService.GetMatchingRide(matchingRide);
            return Ok(result);
        }

        [HttpPost("BookingRide")]
        [Produces("application/json")]
        public async Task<IActionResult> AddBookingRide([FromBody] MatchingRideResponse bookingRideRequest)
        {
            MatchingRideResponse result = await _matchingRidesService.AddBookingRide(bookingRideRequest);
            return Ok(result); 
        }
    }
}
