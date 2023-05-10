using Core.Enums;
using Microsoft.EntityFrameworkCore;
using TechnoTestVk.DAL.Interfaces;
using TechnoTestVk.DAL.Models;

namespace TechnoTestVk.DAL
{
    public class UserRepository: IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<UserEntity>> GetAllUsersAsync()
        {
            return _context.Users
                    .Include(a => a.UserGroup)
                    .Include(a => a.UserState)
                    .ToList();
        }

        public async Task<UserEntity> GetUserByIdAsync(int userId)
        {
            return _context.Users
                    .Include(a => a.UserState)
                    .Include(a => a.UserGroup)
                    .ToList()
                    .Find(a => a.Id == userId)!;
        }

        public async Task<int> GetStateIdBlockedAsync()
        {
            return _context.UserStates
                .SingleOrDefault(a => a.Code == StateStatus.Blocked)!.Id;
        }

        public async Task<int> GetStateIdActiveAsync()
        {
            return _context.UserStates
                .SingleOrDefault(a => a.Code == StateStatus.Active)!.Id;
        }
        
        public async Task<int> GetGroupIdAdminAsync()
        {
            return _context.UserGroups
                .SingleOrDefault(a => a.Code == GroupStatus.Admin)!.Id;
        }

        public async Task<UserEntity> CreateUserAsync(UserEntity user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return _context.Users
                    .Include(a => a.UserGroup)
                    .Include(a => a.UserState)
                    .Single(a => a.Id == user.Id);
        }

        public async Task<bool> TheExistenceOfAdmin()
        {
            int groupAdminId = await GetGroupIdAdminAsync();
            int stateActiveId = await GetStateIdActiveAsync();

            var result = _context.Users
                    .Any(a => a.UserStateId == stateActiveId && a.UserGroupId == groupAdminId);
            
            return result;
        }

        public async Task<bool> TheExistenceOfLogin(string login)
        {
            int stateActiveId = await GetStateIdActiveAsync();

            var result = _context.Users
                    .Any(a => a.UserStateId == stateActiveId && a.Login == login);

            return result;
        }

        public async void DeleteUserAsync(int userId, int stateId)
        {
            UserEntity existUser = _context.Users
                .Include(a => a.UserGroup)
                .Include(a => a.UserState)
                .Single(a => a.Id == userId);
            existUser.UserStateId = stateId;

            _context.SaveChanges();
        }
    }
}
