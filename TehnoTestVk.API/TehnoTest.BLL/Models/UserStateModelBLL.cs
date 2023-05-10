using Core.Enums;

namespace TehnoTest.BLL.Models
{
    public class UserStateModelBLL
    {
        public int Id { get; set; }

        public StateStatus Code { get; set; }

        public string Description { get; set; }
    }
}
