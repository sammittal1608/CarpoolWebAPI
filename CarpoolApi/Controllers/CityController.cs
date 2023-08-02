using Carpool.Repository.Interface;
using Carpool.Services;
using Carpool.Services.Interface;
using CarPool.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [HttpGet("")]
        [Produces("application/json")]
        public IActionResult GetCities()
        {
            List<IntermediaryStop> cities = _cityService.GetAllCities();
            return Ok(cities);
        }
    }
}
