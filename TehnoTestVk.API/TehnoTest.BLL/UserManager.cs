using AutoMapper;
using TechnoTestVk.DAL.Interfaces;
using TechnoTestVk.DAL.Models;
using TehnoTest.BLL.Interfaces;
using TehnoTest.BLL.Models;

namespace TehnoTest.BLL
{
    public class UserManager : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserManager(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserModelBLL>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var result = _mapper.Map<IEnumerable<UserModelBLL>>(users);

            return result;
        }

        public async Task<UserModelBLL> CreateUserAsync(UserModelBLL userBll)
        {
            var userEntity = _mapper.Map<UserEntity>(userBll);

            if (userEntity.UserGroupId == await _userRepository.GetGroupIdAdminAsync())
            {                        
                if (await _userRepository.TheExistenceOfAdmin())
                {
                    throw new Exception("Admin существует");
                }
            }

            if(await _userRepository.TheExistenceOfLogin(userBll.Login))
            {
                throw new Exception("Пользователь с таким логином существует");
            }

            userEntity.CreatedDate = DateTime.UtcNow;
            userEntity.UserStateId = await _userRepository.GetStateIdActiveAsync();

            var user = await _userRepository.CreateUserAsync(userEntity);

            var result = _mapper.Map<UserModelBLL>(user);

            return result;

        }

        public async void DeleteUserAsync(int userId)
        {
            int stateId = await _userRepository.GetStateIdBlockedAsync();
            _userRepository.DeleteUserAsync(userId, stateId);
        }

        public async Task<UserModelBLL> GetUserByIdAsync(int userId)
        {
            var userEntity = await _userRepository.GetUserByIdAsync(userId);

            var result = _mapper.Map<UserModelBLL>(userEntity);

            return result;
        }
    }
}
