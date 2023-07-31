using CarPool.Data;
namespace Carpool.Services.Interface
{
    public interface IUserDetailsService
    {
        Task<User> GetUserDetailsByEmail(string email);
        Task<User> UpdateUserDetails(User user);
        //public List<User> GetUsersByofferRides(List<OfferRide> offerRides);
        Task<List<User>> GetUsers();
        Task<User> AddUser(User user);
        Task<User> GetUserByUserId(string id);
        bool IsUserExistByEmail(string email);
    }
}
