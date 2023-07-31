using CarPool.Data;

namespace Carpool.Services.Interaface
{
    public interface IBookedRidesService
    {
        List<BookedRide> GetBookedRides(string customerId);
    }
}
