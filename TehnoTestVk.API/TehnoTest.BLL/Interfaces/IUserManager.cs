using TehnoTest.BLL.Models;

namespace TehnoTest.BLL.Interfaces
{
    public interface IUserManager
    {
        public Task<IEnumerable<UserModelBLL>> GetAllUsersAsync();
        public Task<UserModelBLL> CreateUserAsync(UserModelBLL user);
        public void DeleteUserAsync(int userId);
        public Task<UserModelBLL> GetUserByIdAsync(int userId);
    }
}
