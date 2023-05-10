using Core.Enums;

namespace TehnoTestVk.API.Models.UserStateModels.Response
{
    public class UserStateResponse
    {
        public int Id { get; set; }
        public StateStatus Code { get; set; }
        public string Description { get; set; }
    }
}
