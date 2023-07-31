using CarPool.Data.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Repository.Interface
{
    public interface IOfferRideRepository
    {
        Task<DBOfferRide> Add(DBOfferRide dbOfferRide);
        DBOfferRide Update(DBOfferRide dbOfferRide);
        List<DBOfferRide> GetAll();
        Task<DBOfferRide> GetById(string id);
    }
}
