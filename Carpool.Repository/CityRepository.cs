using Carpool.Repository.Interface;
using CarPool.Data;
using CarPool.Data.DBModels;


namespace Carpool.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _dbContext;
        public CityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IntermediaryStop> Add(IntermediaryStop city)
        {
           await _dbContext.Cities.AddAsync(city);
            return city;
        }

        public List<IntermediaryStop> GetAll()
        {
            return _dbContext.Cities.ToList();
        }

        public string GetIdByName(string CityName)
        {
            return _dbContext.Cities.FirstOrDefault(city => city.Name == CityName).Id;
           
        }
    }
}
