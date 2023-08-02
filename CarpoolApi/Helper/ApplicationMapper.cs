using AutoMapper;
using CarPool.Data;
using CarPool.Data.DBModels;

namespace CarpoolApi.Helper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<OfferRide, DBOfferRide>()
                .ReverseMap();
            CreateMap<BookedRide, DBBookedRide>()
                .ReverseMap() ;
            //CreateMap<IntermediaryStop, DBIntermediaryStop>()
            //    .ReverseMap() ;
            CreateMap<User,DBUser>()
                .ReverseMap() ;
            CreateMap<DBBookedRide, MatchingRideResponse>()
                .ReverseMap();
        }
    }
}
