namespace TehnoTest.BLL.Models
{
    public class UserModelBLL
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UserGroupId { get; set; }

        public UserGroupModelBLL UserGroup { get; set; }

        public UserStateModelBLL UserState { get; set; }
    }
}
