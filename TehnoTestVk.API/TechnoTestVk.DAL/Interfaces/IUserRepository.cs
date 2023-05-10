using TechnoTestVk.DAL.Models;

namespace TechnoTestVk.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserEntity>> GetAllUsersAsync();
        Task<UserEntity> GetUserByIdAsync(int userId);
        Task<int> GetStateIdBlockedAsync();
        Task<int> GetStateIdActiveAsync();
        Task<int> GetGroupIdAdminAsync();
        Task<bool> TheExistenceOfAdmin();
        Task<bool> TheExistenceOfLogin(string login);
        Task<UserEntity> CreateUserAsync(UserEntity user);        
        void DeleteUserAsync(int userId, int stateId);
    }
}
