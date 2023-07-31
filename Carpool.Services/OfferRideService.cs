using AutoMapper;
using CarPool.Data.DBModels;
using CarPool.Data;
using Carpool.Repository.Interface;
using Carpool.Services.Interface;
namespace Carpool.Services
{
    public class OfferRideService : IOfferRideService
    {
        IOfferRideRepository _offerRideRepository;
        IMapper _mapper;
        IUserDetailsService _userDetailsService;
        IUnitOfWork _UnitOfWork;
        public OfferRideService(IOfferRideRepository offerRideRepository, IMapper mapper, IUserDetailsService userDetailsService, IUnitOfWork unitOfWork)
        {
            _offerRideRepository = offerRideRepository;
            _userDetailsService = userDetailsService;
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
        }
        public async Task<OfferRide> AddOfferingRide(OfferRide offerRide)
        {
            var dbOfferRide = _mapper.Map<DBOfferRide>(offerRide);
            dbOfferRide = await _offerRideRepository.Add(dbOfferRide);
            offerRide = _mapper.Map<OfferRide>(dbOfferRide);
            await _UnitOfWork.SaveChanges();
            return offerRide;
        }
        public List<OfferRide> GetAllOfferRides()
        {
            List<DBOfferRide> dbOfferRides = _offerRideRepository.GetAll();
            return _mapper.Map<List<OfferRide>>(dbOfferRides);
        }
        

        public async Task<List<OfferRide>> GetOfferedRide(string email)
        {
            List<OfferRide> offerRides = GetAllOfferRides();
            User user = await _userDetailsService.GetUserDetailsByEmail(email);
            return offerRides.Where(ride => ride.OwnerId.Equals(user.UserId)).ToList();
        }

        public async Task<OfferRide> UpdateOfferRide(OfferRide offerRide)
        {
            DBOfferRide dbOfferRide = _mapper.Map<DBOfferRide>(offerRide);
            dbOfferRide = _offerRideRepository.Update(dbOfferRide);
            OfferRide updatedOfferRide = _mapper.Map<OfferRide>(dbOfferRide);
            _UnitOfWork.SaveChanges();
            return updatedOfferRide;
        }

        public async Task<OfferRide> GetOfferRideByUserId(string userId)
        {

            List<OfferRide> offerRides = GetAllOfferRides();
            return offerRides.FirstOrDefault(o => o.OwnerId == userId);


        }
    }
}