using AutoMapper;
using Carpool.Repository;
using Carpool.Repository.Interface;
using Carpool.Services.Interaface;
using Carpool.Services.Interface;
using CarPool.Data;
using CarPool.Data.DBModels;

namespace Carpool.Services
{
    public class BookedRidesService :IBookedRidesService
    {
        IBookedRideRepository _bookedRidesRepository;
        IMapper _mapper;
        public BookedRidesService(IBookedRideRepository bookedRidesRepository, IMapper mapper,IUnitOfWork unitOfWork)
        {
            _bookedRidesRepository = bookedRidesRepository;
            _mapper = mapper;
        }
        public List<BookedRide> GetBookedRides(string CustomerId)
        {
            List<DBBookedRide> dbBookedRides = _bookedRidesRepository.GetAll();
            return dbBookedRides.Select(dbRide =>
            {
                BookedRide bookedRide = _mapper.Map<BookedRide>(dbRide);
                bookedRide.CustomerId = CustomerId;
                return bookedRide;
            }).ToList();

            
        }
    }
}
