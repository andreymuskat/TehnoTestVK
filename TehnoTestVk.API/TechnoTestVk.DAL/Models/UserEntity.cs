using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechnoTestVk.DAL.Models
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(UserGroupId))]
        public UserGroupEntity UserGroup { get; set; }

        public int UserGroupId { get; set; }

        [ForeignKey(nameof(UserStateId))]
        public UserStateEntity UserState { get; set; }

        public int UserStateId { get; set; }
    }
}
