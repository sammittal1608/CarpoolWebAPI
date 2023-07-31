using CarPool.Data;
using CarPool.Data.DBModels;
using Carpool.Repository.Interface;
using Microsoft.EntityFrameworkCore;


namespace Carpool.Repository
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private AppDbContext _dbContext;
        public UserDetailsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DBUser> AddUser(DBUser userDetails)
        {
            await _dbContext.Users.AddAsync(userDetails);

            return userDetails;
        }

        public async Task<DBUser> GetUserById(string Id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(e => e.UserId == Id);

        }
        public async Task<DBUser> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public DBUser UpdateUserDetails(DBUser userDetails)
        {
            var dbUser = _dbContext.Users.Attach(userDetails);
            dbUser.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return userDetails;
        }
        public  List<DBUser> GetUsers()
        {
            return _dbContext.Users.ToList();
        }
    }
}
