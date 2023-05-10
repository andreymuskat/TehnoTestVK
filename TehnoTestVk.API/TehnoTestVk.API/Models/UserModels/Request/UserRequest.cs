namespace TehnoTestVk.API.Models.UserModels.Request
{
    public class UserRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserGroupId { get; set; }
    }
}
