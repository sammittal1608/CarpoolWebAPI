using Carpool.Repository.Interface;
using CarPool.Data;
using CarPool.Data.DBModels;

namespace Carpool.Repository
{
    public class BookedRideRepository:IBookedRideRepository
    {
        private readonly AppDbContext dbContext;

        public BookedRideRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<DBBookedRide> Add(DBBookedRide dbBookedRide)
        {
           await dbContext.BookedRides.AddAsync(dbBookedRide);
           return dbBookedRide;
        }
        public List<DBBookedRide> GetAll()
        {
            return dbContext.BookedRides.ToList();
        }
    }
}
