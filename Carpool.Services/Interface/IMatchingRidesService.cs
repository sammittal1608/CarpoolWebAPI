using CarPool.Data;
namespace Carpool.Services.Interaface
{
    public interface IMatchingRidesService
    {
        Task<List<MatchingRideResponse>> GetMatchingRide(MatchingRideRequest bookRide);
        Task<MatchingRideResponse> AddBookingRide(MatchingRideResponse bookRideResponse);
        public bool IsRideMatch(OfferRide offerRide, MatchingRideRequest matchingRideRequest);
    }
}
