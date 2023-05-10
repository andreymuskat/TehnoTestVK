using Core.Enums;

namespace TehnoTestVk.API.Models.UserGroupModels.Response
{
    public class UserGroupResponse
    {
        public int Id { get; set; }
        public GroupStatus Code { get; set; }
        public string Description { get; set; }
    }
}
