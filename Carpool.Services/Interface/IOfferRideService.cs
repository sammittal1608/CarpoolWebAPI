using CarPool.Data;
namespace Carpool.Services.Interface
{
    public interface IOfferRideService
    {
        Task<OfferRide> AddOfferingRide(OfferRide offerRide);
        List<OfferRide> GetAllOfferRides();
        //Task<OfferRide> DeleteOfferRide(string offerRideId);
        Task<List<OfferRide>> GetOfferedRide(string userId);
        Task<OfferRide> UpdateOfferRide(OfferRide offerRide);
        Task<OfferRide> GetOfferRideByUserId(string id);
    }
}
