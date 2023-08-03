﻿using CarPool.Data;
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

        [HttpGet("{ownerId}")]
        public async Task<IActionResult> GetOfferedRides(string ownerId)
        {
            try
            {     
                List<BookedRide> result = await _offerRideService.GetOfferedRide(ownerId);
                return Ok(result); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error"); 
            }
        }
    }
}
