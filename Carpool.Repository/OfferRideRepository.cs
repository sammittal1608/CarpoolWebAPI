using CarPool.Data.DBModels;
using CarPool.Data;
using Carpool.Repository.Interface;

namespace Carpool.Repository
{
    public class OfferRideRepository : IOfferRideRepository
    {
        private readonly AppDbContext _dbContext;
        public OfferRideRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DBOfferRide> Add(DBOfferRide dbOfferRide)
        {
            await _dbContext.OfferRides.AddAsync(dbOfferRide);
            return dbOfferRide;
        }
        public DBOfferRide Update(DBOfferRide dbOfferRideChanges)
        {
            var existingOfferRide = _dbContext.OfferRides.FirstOrDefault(ride => ride.OwnerId == dbOfferRideChanges.OwnerId);

            if (existingOfferRide != null)
            {

                existingOfferRide.Source = dbOfferRideChanges.Source;
                existingOfferRide.Destination = dbOfferRideChanges.Destination;
                existingOfferRide.Date = dbOfferRideChanges.Date;
                existingOfferRide.RideValidFrom = dbOfferRideChanges.RideValidFrom;
                existingOfferRide.RideValidTill = dbOfferRideChanges.RideValidTill;
                existingOfferRide.AvailableSeats = dbOfferRideChanges.AvailableSeats;
                existingOfferRide.IntermediaryStops = dbOfferRideChanges.IntermediaryStops;
                existingOfferRide.Price = dbOfferRideChanges.Price;
                existingOfferRide.IsRideBooked = dbOfferRideChanges.IsRideBooked;
                existingOfferRide.CustomerId = dbOfferRideChanges.CustomerId;

                _dbContext.SaveChanges();
            }

            return existingOfferRide;
        }

        public List<DBOfferRide> GetAll()
        {
            List<DBOfferRide> dBOfferRides = _dbContext.OfferRides.ToList();
            return dBOfferRides;
        }

        public async Task<DBOfferRide> GetById(string dbOfferRideId)
        {
            return await _dbContext.OfferRides.FindAsync(dbOfferRideId);
        }
    }
}
