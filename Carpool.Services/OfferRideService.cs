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
        ICityService _cityService;
        public OfferRideService(IOfferRideRepository offerRideRepository, IMapper mapper, IUserDetailsService userDetailsService, IUnitOfWork unitOfWork, ICityService cityService)
        {
            _offerRideRepository = offerRideRepository;
            _userDetailsService = userDetailsService;
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
            _cityService = cityService;
        }
        public async Task<OfferRide> AddOfferingRide(OfferRide offerRide)
        {
            for (int i = 0; i < offerRide.IntermediaryStops.Count; i++)
            {
                if (IsCityStored(offerRide.IntermediaryStops[i].Name))
                {
                    offerRide.IntermediaryStops[i].Id = Guid.NewGuid().ToString();
                    //IntermediaryStop city = new IntermediaryStop()
                    //{
                    //    Id= offerRide.IntermediaryStops[i].Id,
                    //    Name = offerRide.IntermediaryStops[i].Name,
                    //}
                    _cityService.AddCity(offerRide.IntermediaryStops[i]);
                    
                }
                else
                {
                offerRide.IntermediaryStops[i].Id = _cityService.GetCityIdbyCityName(offerRide.IntermediaryStops[i].Name);
                }
                
            }
            offerRide.RideId = Guid.NewGuid().ToString();
            var dbOfferRide = _mapper.Map<DBOfferRide>(offerRide);
            dbOfferRide = await _offerRideRepository.Add(dbOfferRide);
            offerRide = _mapper.Map<OfferRide>(dbOfferRide);
            await _UnitOfWork.SaveChanges();
            return offerRide;
        }
        private bool IsCityStored(string cityName)
        {
            List<IntermediaryStop> cities = _cityService.GetAllCities();

            return (cities.FirstOrDefault(city => city.Name.Equals(cityName, StringComparison.CurrentCultureIgnoreCase)) == null);
            }

        public List<OfferRide> GetAllOfferRides()
        {
            List<DBOfferRide> dbOfferRides = _offerRideRepository.GetAll();
            return _mapper.Map<List<OfferRide>>(dbOfferRides);
        }
        

        public async Task<List<BookedRide>> GetOfferedRide(string userId)
        {
            List<OfferRide> offerRides = GetAllOfferRides();
            
            //offerRides =  offerRides.Where(ride => ride.OwnerId.Equals(user.UserId)).ToList();
            
            List<BookedRide> offeredRides = new List<BookedRide>();
            foreach(OfferRide offerRide in offerRides)
            {
                User user = await _userDetailsService.GetUserByUserId(userId);
                if (offerRide.IsRideBooked && offerRide.OwnerId.Equals(user.UserId, StringComparison.OrdinalIgnoreCase))
                {
                    BookedRide offeredRide = new BookedRide()
                    {
                        OwnerId = offerRide.OwnerId,
                        CustomerId = offerRide.CustomerId,
                        Source = offerRide.Source,
                        Destination = offerRide.Destination,
                        Date = offerRide.Date,
                        ValidFrom = offerRide.RideValidFrom,
                        ValidTill = offerRide.RideValidTill,
                        Price = offerRide.Price,
                        SeatsBooked = offerRide.AvailableSeats,
                        FirstName = user.FirstName,

                    };
                    offeredRides.Add(offeredRide);
                } 
            }
            return offeredRides;
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