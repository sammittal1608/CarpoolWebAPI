using CarPool.Data.DBModels;

namespace Carpool.Repository.Interface
{
    public interface IBookedRideRepository
    {
         List<DBBookedRide> GetAll();
         Task<DBBookedRide> Add(DBBookedRide dbBookedRide);
    }
}
