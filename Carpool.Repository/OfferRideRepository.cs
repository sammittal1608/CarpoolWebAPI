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
        public  DBOfferRide Update(DBOfferRide dbOfferRideChanges)
        {
            var dbOfferRide = _dbContext.OfferRides.Attach(dbOfferRideChanges);
            dbOfferRide.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return dbOfferRideChanges;

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
