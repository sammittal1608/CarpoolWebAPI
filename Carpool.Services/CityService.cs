using Carpool.Repository.Interface;
using Carpool.Services.Interface;
using CarPool.Data;

namespace Carpool.Services
{
    public class CityService : ICityService
    {
        ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IntermediaryStop> AddCity(IntermediaryStop city)
        {
            await _cityRepository.Add(city);
            return city;
        }
        public List<IntermediaryStop> GetAllCities()
        {
           return _cityRepository.GetAll();
        }

        public string GetCityIdbyCityName(string cityName)
        {
           return _cityRepository.GetIdByName(cityName);
        }
    }
}
