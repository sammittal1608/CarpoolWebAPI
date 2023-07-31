using CarPool.Data.DBModels;
namespace Carpool.Repository.Interface
{
    public interface IUserDetailsRepository
    {
        Task<DBUser> AddUser(DBUser dbUser);
        Task<DBUser> GetUserById(string Id);
        Task<DBUser> GetUserByEmail(string email);
        DBUser UpdateUserDetails(DBUser user);
        List<DBUser> GetUsers();
    }
}
