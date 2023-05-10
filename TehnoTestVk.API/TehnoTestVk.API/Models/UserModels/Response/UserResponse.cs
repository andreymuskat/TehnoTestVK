using TehnoTestVk.API.Models.UserGroupModels.Response;
using TehnoTestVk.API.Models.UserStateModels.Response;

namespace TehnoTestVk.API.Models.UserModels.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserGroupResponse UserGroup { get; set; }
        public UserStateResponse UserState { get; set; }
    }
}
