using AutoMapper;
using CarPool.Data.DBModels;
using CarPool.Data;
using Carpool.Services.Interaface;
using Carpool.Services.Interface;
using Carpool.Repository.Interface;

namespace Carpool.Services
{
    public class MatchingRidesService:IMatchingRidesService
    {
        IOfferRideService _offerRidesService;
        IUserDetailsService _userDetailsService;
        IMapper _mapper;
        IBookedRideRepository _bookedRidesRepository;
        IUnitOfWork _unitOfWork;
        public MatchingRidesService( IOfferRideService offerRideService, IUserDetailsService userDetailsService, IMapper mapper, IBookedRideRepository bookedRidesRepository, IUnitOfWork unitOfWork)
        {

            _offerRidesService = offerRideService;
            _userDetailsService = userDetailsService;
            _bookedRidesRepository = bookedRidesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<MatchingRideResponse>> GetMatchingRide(MatchingRideRequest matchingRideRequest)
        {
            List<OfferRide> offerRides = _offerRidesService.GetAllOfferRides();
            List<MatchingRideResponse> matchingRidesResponse = new List<MatchingRideResponse>();
            User customer = await _userDetailsService.GetUserByUserId(matchingRideRequest.CustomerId);

            foreach (OfferRide offerRide in offerRides)
            {
                if (IsRideMatch(offerRide, matchingRideRequest))
                {
                    User user = await _userDetailsService.GetUserByUserId(offerRide.OwnerId);
                    MatchingRideResponse matchingRideResponse = new MatchingRideResponse();
                    matchingRideResponse.FirstName = user.FirstName;
                    matchingRideResponse.LastName = user.LastName;
                    matchingRideResponse.OwnerId = user.UserId;
                    matchingRideResponse.Destination = offerRide.Destination;
                    matchingRideResponse.Source = offerRide.Source;
                    matchingRideResponse.Date = offerRide.Date;
                    matchingRideResponse.CustomerId = customer.UserId;
                    matchingRideResponse.ValidFrom = offerRide.RideValidFrom;
                    matchingRideResponse.ValidTill = offerRide.RideValidTill;
                    matchingRideResponse.AvailableSeats = offerRide.AvailableSeats;
                    matchingRideResponse.Price = offerRide.Price;
                    matchingRidesResponse.Add(matchingRideResponse);
                }
            }

            return matchingRidesResponse;
        }
        public bool IsRideMatch(OfferRide offerRide, MatchingRideRequest matchingRideRequest)
        {
            if (matchingRideRequest.Source != offerRide.Source ||
                matchingRideRequest.Destination != offerRide.Destination ||
                matchingRideRequest.RideValidFrom != offerRide.RideValidFrom ||
                matchingRideRequest.RideValidTill != offerRide.RideValidTill ||
                offerRide.AvailableSeats < 1 ||
                offerRide.IntermediaryStops == null || !offerRide.IntermediaryStops.Any() ||
                !offerRide.IntermediaryStops.Any(stop => stop.Name == matchingRideRequest.Source) ||
                !offerRide.IntermediaryStops.Any(stop => stop.Name == matchingRideRequest.Destination))
            {
                return false;
            }

            var sourceStop = offerRide.IntermediaryStops.FirstOrDefault(stop => stop.Name == matchingRideRequest.Source);
            var destinationStop = offerRide.IntermediaryStops.FirstOrDefault(stop => stop.Name == matchingRideRequest.Destination);

            if (destinationStop == null || sourceStop == null)
            {
                return false;
            }

            var intermediaryStopsList = offerRide.IntermediaryStops.ToList();
            int sourceIndex = intermediaryStopsList.IndexOf(sourceStop);
            int destinationIndex = intermediaryStopsList.IndexOf(destinationStop);

            return destinationIndex > sourceIndex;
        }


        public async Task<MatchingRideResponse> AddBookingRide(MatchingRideResponse bookingRideReponse)
        {
            OfferRide offerRide = await _offerRidesService.GetOfferRideByUserId(bookingRideReponse.OwnerId);
            offerRide.AvailableSeats--; 
            offerRide.IsRideBooked = true;
            await _offerRidesService.UpdateOfferRide(offerRide);
            DBBookedRide dbBookedRide = _mapper.Map<DBBookedRide>(bookingRideReponse);
            dbBookedRide = await _bookedRidesRepository.Add(dbBookedRide);
            MatchingRideResponse addedBookedRide = _mapper.Map<MatchingRideResponse>(dbBookedRide);
            await _unitOfWork.SaveChanges();
            return addedBookedRide;
        }
    }
}
