using CarPool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Repository.Interface
{
    public interface ICityRepository
    {
        Task<IntermediaryStop> Add(IntermediaryStop city);
        List<IntermediaryStop> GetAll();
        string GetIdByName(string CityName);
    }
}
