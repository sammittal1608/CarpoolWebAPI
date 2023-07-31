using CarPool.Data;
using Carpool.Services.Interaface;
using Microsoft.AspNetCore.Mvc;

namespace CarPool.Controllers
{
    public class BookedRideController : Controller
    {
        IBookedRidesService _bookedRidesService;
        public BookedRideController(IBookedRidesService bookedRidesService)
        {
            _bookedRidesService = bookedRidesService;
        }
        [HttpGet("")]
        [Produces("application/json")]
        public List<BookedRide> GetAllBookedRide(string CustomerId)
        {
            return _bookedRidesService.GetBookedRides(CustomerId);

        }
    }
}
