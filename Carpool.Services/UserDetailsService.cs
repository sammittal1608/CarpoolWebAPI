using AutoMapper;
using CarPool.Data.DBModels;
using CarPool.Data;
using Carpool.Repository.Interface;
using Carpool.Services.Interface;

namespace Carpool.Services
{
    public class UserDetailsService : IUserDetailsService
    {
        IUserDetailsRepository _userDetailsRepository;
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        public UserDetailsService(IUserDetailsRepository userDetailsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userDetailsRepository = userDetailsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<User> GetUserDetailsByEmail(string email)
        {
            DBUser dbUser = await _userDetailsRepository.GetUserByEmail(email);
            if (dbUser == null)
            {
                return null;
            }
            return _mapper.Map<User>(dbUser);

        }
        public async Task<User> UpdateUserDetails(User user)
        {
            DBUser dbUser = _mapper.Map<DBUser>(user);
            dbUser = _userDetailsRepository.UpdateUserDetails(dbUser);
            User UpdatedUser = _mapper.Map<User>(dbUser);
            await _unitOfWork.SaveChanges();
            return UpdatedUser;
        }
        public async Task<User> AddUser(User user)
        {
            DBUser dbUser = _mapper.Map<DBUser>(user);
            dbUser = await _userDetailsRepository.AddUser(dbUser);
            user = _mapper.Map<User>(dbUser);
            await _unitOfWork.SaveChanges();
            return user;
        }
        public async Task<List<User>> GetUsers()
        {
            List<DBUser> dbUsers = _userDetailsRepository.GetUsers();
            return _mapper.Map<List<User>>(dbUsers);

        }
        public async Task<User> GetUserByUserId(string id)
        {
            DBUser dBUser = await _userDetailsRepository.GetUserById(id);
            return _mapper.Map<User>(dBUser);

        }
        public bool IsUserExistByEmail(string email)
        {
            List<DBUser> dbUsers = _userDetailsRepository.GetUsers();
            List<User> users = _mapper.Map<List<User>>(dbUsers);
            return users.FirstOrDefault(u => u.Email == email) != null;
        }
    }
}
