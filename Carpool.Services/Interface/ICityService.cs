using CarPool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services.Interface
{
    public interface ICityService
    {
        List<IntermediaryStop> GetAllCities();
        string GetCityIdbyCityName(string cityName);
        Task <IntermediaryStop> AddCity(IntermediaryStop city);
    }
}
